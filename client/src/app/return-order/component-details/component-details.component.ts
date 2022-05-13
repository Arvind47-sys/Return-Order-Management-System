import { Component, HostListener, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, Subscription } from 'rxjs';
import { DefectiveComponentType } from 'src/app/constants/return-order-constants';
import { ComponentDetails } from 'src/app/models/component-details.model';
import { PaymentInfo } from 'src/app/models/payment.model';
import { ProcessingChargeDetails } from 'src/app/models/processing-charge.model';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { ComponentProcessingService } from 'src/app/services/component-processing.service';

@Component({
  selector: 'app-component-details',
  templateUrl: './component-details.component.html',
  styleUrls: ['./component-details.component.css']
})
export class ComponentDetailsComponent implements OnInit, OnDestroy {

  editMode: boolean;
  detailMode: boolean;
  subscription: Subscription = new Subscription();
  loggedInUser = {} as User;
  @ViewChild('processingForm') processingForm: NgForm;
  @ViewChild('completeProcessingForm') completeProcessingForm: NgForm;
  componentDetails = { defectiveComponentType: DefectiveComponentType.INTEGRAL } as ComponentDetails;
  processingChargeDetails: ProcessingChargeDetails;
  paymentDetails = {} as PaymentInfo;
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.componentProcessingService.getProcessState()) {
      $event.returnValue = true;
    }
  }

  constructor(private componentProcessingService: ComponentProcessingService,
    private accountService: AccountService, private router: Router,
    private toastr: ToastrService) {
      this.subscription.add(this.accountService.currentUser$.subscribe(user => {
        this.loggedInUser = user;
      }))
  }

  processCompletionState$ = this.componentProcessingService.proceesStatusState$;


  ngOnInit(): void {
    this.componentProcessingService.setProcessState();
    this.editMode = true;
    this.subscription.add(this.accountService.currentUser$.subscribe(user => {
      if(user)
      {
        this.loggedInUser = user;
      }
    }))
  }

  submitProcessingForm() {
    this.componentProcessingService.processDetail(this.componentDetails).subscribe(
      data => {
        if (data) {
          this.componentDetails.id = data.requestId;
          this.paymentDetails.requestId = data.requestId;
          this.paymentDetails.totalProcessingCharge = data.processingCharge + data.packagingAndDeliveryCharge;
          this.paymentDetails.processResponse = data;
          this.processingForm.reset(this.componentDetails);
          this.processingChargeDetails = data;
          this.detailMode = true;
          this.editMode = false;
        }

      }
    )
  }

  toggleEditMode() {
    this.editMode = true;
    this.detailMode = false;
  }

  cancelEditMode() {
    this.editMode = false;
    this.detailMode = true;
  }

  cancelOrder() {
    this.componentProcessingService.resetProcessState();
      if (confirm('Are you sure you want to cancel!')) {
        this.router.navigateByUrl('/');
      }
      else {
        this.componentProcessingService.setProcessState();
      }
    }

  confirmOrder() {
    this.componentProcessingService.completeProcessing(this.paymentDetails).subscribe((data => {
      if (data) {
        this.componentProcessingService.resetProcessState();
        this.router.navigateByUrl('/');
      }
      else
        this.toastr.error('Error when Saving the request');
    }))
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.componentProcessingService.resetProcessState();
  }
}

