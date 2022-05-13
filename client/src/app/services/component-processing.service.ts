import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ComponentDetails } from 'src/app/models/component-details.model';
import { PaymentInfo } from '../models/payment.model';
import { ProcessingChargeDetails } from '../models/processing-charge.model';

@Injectable({
  providedIn: 'root'
})
export class ComponentProcessingService {
 
  baseUrl = 'https://localhost:5001/api/';

  private proceesStatusStore = new BehaviorSubject<boolean>(false);
  public proceesStatusState$ = this.proceesStatusStore.asObservable();

  constructor(private http: HttpClient) { }

  processDetail(componentDetails: ComponentDetails) : Observable<ProcessingChargeDetails>
  {
    return this.http.post<ProcessingChargeDetails>(this.baseUrl + 'componentProcessing/processDetail', componentDetails);
  }

  completeProcessing(paymentDetails: PaymentInfo) {
    return this.http.post<boolean>(this.baseUrl + 'componentProcessing/completeProcessing', paymentDetails);
  }

  getProcessState() {
    return this.proceesStatusStore.value;
  }

  setProcessState() {
    this.proceesStatusStore.next(true);
  }

  resetProcessState() {
    this.proceesStatusStore.next(false);
  }

}
