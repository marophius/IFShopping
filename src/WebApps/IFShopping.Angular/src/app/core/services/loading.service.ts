import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  public loadingReqCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  public loading() {
    this.loadingReqCount++;
    this.spinnerService.show(undefined, {
      type: 'ball-pulse-sync',
      bdColor: 'rgba(255,255,255,0.7)',
      color: '#333333'
    });
  }

  public idle() {
    this.loadingReqCount--;
    if(this.loadingReqCount <= 0){
      this.loadingReqCount = 0;
      this.spinnerService.hide();
    }
  }

}
