import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../models/user.model';
import { map } from 'rxjs/operators'
import { UserRequestDetails, UserRequestSummary } from '../models/user-request-details.model';
import { Router } from '@angular/router';

const _currentUserState = null;
const _currentUserReturnRequestsState = [];

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = 'https://localhost:5001/api/';

  private currentUserStore = new BehaviorSubject<User>(_currentUserState);
  public currentUser$ = this.currentUserStore.asObservable();

  private currentUserReturnRequests = new BehaviorSubject<UserRequestSummary[]>(_currentUserReturnRequestsState);
  public currentUserReturnRequests$ = this.currentUserReturnRequests.asObservable();

  private tokenExpirationTimer: any;

  constructor(private http: HttpClient, private router: Router) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.setCurrentUser(user);
          this.initiateAutoLogOut(user);
          return user;
        }
      }

      )
    )
  }

  initiateAutoLogOut(user: User) {
    const exp = (JSON.parse(atob(user.token.split('.')[1]))).exp;
    const expires = new Date(exp * 1000);
    const timeout = expires.getTime() - Date.now() - (60 * 1000);
      this.tokenExpirationTimer = setTimeout(() => {
        this.logOut();
      }, timeout);
  }  

  setCurrentUser(user: User) {
    this.currentUserStore.next(user);
  }

  logOut() {
    localStorage.removeItem('user');
    this.currentUserStore.next(_currentUserState);
    this.currentUserReturnRequests.next(_currentUserReturnRequestsState);
    this.router.navigateByUrl('/').then(() => {
      window.location.reload();
    });
    if (this.tokenExpirationTimer) {
      clearTimeout(this.tokenExpirationTimer);
    }
    this.tokenExpirationTimer = null;
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((user: User) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserStore.next(user);
          this.initiateAutoLogOut(user);
        }
      })
    );
  }

  getAllUserRequests(): Observable<UserRequestSummary[]> {
    return this.http.get<UserRequestDetails>(this.baseUrl + 'users/getAllUserReturnRequests').pipe(
      map(requests => {
        const userRequestSummary: UserRequestSummary[] = [];
        if (requests)
          requests.processRequests.forEach(req => {
            const userRequest = {} as UserRequestSummary;
            var processCharge = requests.processResponses.find(resp => resp.requestId === req.id);
            if (processCharge) {
              userRequest.requestId = processCharge.requestId;
              userRequest.defectiveComponentName = req.defectiveComponentName;
              userRequest.defectiveComponentType = req.defectiveComponentType;
              userRequest.quantity = req.quantity;
              userRequest.processingCharge = processCharge.processingCharge;
              userRequest.packagingAndDeliveryCharge = processCharge.packagingAndDeliveryCharge;
              userRequest.dateOfDelivery = processCharge.dateOfDelivery;
              userRequestSummary.push(userRequest);
            }
          });
        this.currentUserReturnRequests.next(userRequestSummary);
        return userRequestSummary;
      })
    );
  }


}
