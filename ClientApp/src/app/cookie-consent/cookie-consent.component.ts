import { Component, Input, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-cookie-consent',
  templateUrl: './cookie-consent.component.html',
  styleUrls: ['./cookie-consent.component.css']
})
export class CookieConsentComponent implements OnInit {
@Input() cookiesEnabled:boolean;
displayStyle = "block";
check:string;
  constructor(private cookieService:CookieService) { }

  ngOnInit(): void {
    this.check = this.cookieService.get('cookieConsent');
    if(this.check==="true"){
      this.displayStyle="none";
    } else {
      setTimeout(() => {
        this.displayStyle="none";
      }, 120000);
    }
  }
  open() {
    this.displayStyle = "block";
  }
  dismiss() {
    this.displayStyle = "none";
  }

}
