import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { SpinnerService } from './services/spinner.service';
import {finalize} from 'rxjs/operators';

@Injectable()
export class ApiCallsInterceptor implements HttpInterceptor {

  constructor(private spinner:SpinnerService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.spinner.show();
    return next.handle(request).pipe(
      finalize(()=>{
        this.spinner.hide()
      })
    );
  }
}
