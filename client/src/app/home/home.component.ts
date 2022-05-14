import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  registerMode = false;
  subscription: Subscription = new Subscription;

  constructor(private accountService: AccountService, private toastr: ToastrService,
    private router: Router) { }


  loggedInUserInfo$ = this.accountService.currentUser$;
  loggedInUserReturnRequests$ = this.accountService.currentUserReturnRequests$;


  ngOnInit(): void {
    this.subscription.add(this.loggedInUserInfo$.subscribe(user => {
      if (user) {
        this.accountService.getAllUserRequests().subscribe((requests) => {
          if (requests.length)
            this.toastr.info('Requests Loaded Successfully!');
        });
      }
    }))
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  createNewRequest() {
    this.router.navigateByUrl('/component-details');
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
