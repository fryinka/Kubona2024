import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

declare global {
  interface Window {
    VWO: any;
  }
}

@Injectable({
  providedIn: 'root'
})
export class VwoService {
  private ipApiUrl = 'https://api.ipify.org';
  constructor(private http:HttpClient) {
    // Make sure that the VWO object is available in the window
    window.VWO = window.VWO || [];
    window.VWO.event = window.VWO.event || function () { window.VWO.push(["event"].concat([].slice.call(arguments))) };
  }

  triggerVWOEvent(event:string) {
    // Trigger the "purchase" event
    window.VWO.event(event);
  }

  getUserIPAddress(): Observable<any>{
    return this.http.get(this.ipApiUrl);
  }
}

