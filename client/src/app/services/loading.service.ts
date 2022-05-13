import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  requestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  showLoadingIndicator() 
  {
    this.requestCount++;
    this.spinnerService.show(undefined, {
      bdColor: "rgba(51,51,51,0.8)",
      size: "medium",
      color: "#fff",
      type: "ball-scale-multiple"    
    })
  }

  hideLoadingIndicator() {
    this.requestCount--;
    if(this.requestCount <= 0) {
      this.requestCount = 0;
      this.spinnerService.hide();
    }
  }
}
