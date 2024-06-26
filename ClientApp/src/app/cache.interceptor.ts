import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CacheInterceptor implements HttpInterceptor {
  myDate: Date = new Date();
  expiryDate = (this.myDate.getDay() + 4);
  constructor() {}
  
    intercept( req: HttpRequest<any>,next: HttpHandler): Observable<HttpEvent<any>> {
      if (req.method==='GET'){
        const reqClone = req.clone({
        setHeaders:{
          'Expires':'08/14/2023 17:01:54'
        }
      });
      return next.handle(reqClone);
      } else {
        return next.handle(req);
      }
    }
  }
