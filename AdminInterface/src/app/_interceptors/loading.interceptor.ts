import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, delay, finalize } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  busyRequestCout: any;

  constructor(private spinner: NgxSpinnerService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {


    this.busy();
    //console.log(" iam her bitches...");
    
    return next.handle(request).pipe(
      finalize(() => {
        this.idle()
      })
    );
  }


  busy(){
    this.busyRequestCout++;
    this.spinner.show(undefined, {
      type: 'line-scale-party',
      bdColor: 'rgba(255,255,255,0)',
      color: '#333333'
    })
  }
  idle(){
    this.busyRequestCout--;
    if(this.busyRequestCout <= 0){
      this.busyRequestCout = 0;
      this.spinner.hide();
    }
    
  }
}
