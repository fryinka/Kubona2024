import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { GoogleAnalyticsService } from './services/google-analytics.service';
import { SEOService } from './services/seo.service';
import { SpinnerService } from './services/spinner.service';
import { fromEvent, merge, of, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';


// declare ga as a function to set and sent the events
declare let gtag: Function;
declare let fbq: Function;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'Kubona.ng';
  loading$ = this.spinner.loading$;
  cookieGCLID: string = '';
  cookieFBCLID: string = '';
  myDate: Date = new Date();
  expiryDate = (this.myDate.getDay() + 4);
  cookiesEnabled: boolean;
  userId: string;
  networkStatus: any;
  networkStatus$: Subscription = Subscription.EMPTY;

  constructor(public router: Router, public spinner: SpinnerService, private activateRoute: ActivatedRoute, private cookieService: CookieService, private googleService: GoogleAnalyticsService) {

    // subscribe to router events and send page views to Google Analytics
    this.router.events.subscribe(event => {

      if (event instanceof NavigationEnd) {
        gtag('config', 'UA-1299523-10', { 'page_path': event.urlAfterRedirects });
        gtag('config', '1062104035', { 'page_path': event.urlAfterRedirects });
        // gtag('config', 'G-9CL9JMZ419', {'user_id': this.userID});
        // console.log(this.userID);
        // fbq('init', '712315642623111');
        fbq('track', 'PageView');
        //fbq('init', '453680828887319');
        //fbq('track', 'PageView');


      }

    });
  }
  ngOnInit() {
    this.checkNetworkStatus();
    if (navigator.cookieEnabled) {
      // cookies are enabled
      // read, write and delete cookies
      this.cookiesEnabled = true;
      this.cookieService.set('cookieConsent', "true", { expires: this.expiryDate, path: '/' });
      // console.log("Cookies enabled!");
    }
    else {
      // cookies are disabled, show an error message to the user, or follow other alternative
      // console.log("Please enable cookies to enjoy!");
      this.cookiesEnabled = false
    }
    this.activateRoute.queryParams.subscribe(response => {
      this.cookieGCLID = response.gclid;
      this.cookieFBCLID = response.fbclid;
      const cookieGExists: boolean = this.cookieService.check('gclid');
      const cookieFBExists: boolean = this.cookieService.check('fbclid');
      const userIdExist: boolean = this.cookieService.check('kubona_shopper');
      // console.log("GoogleCookie Exist: ", cookieGExists);
      // console.log("FacebookCookie Exist: ", cookieFBExists);
      if (this.cookieGCLID != null) {
        // this.cookie = a.replace(/+/g,' ');
        this.cookieService.set('gclid', this.cookieGCLID, { expires: this.expiryDate, path: '/' });
        // console.log("Google Cookie: ", this.cookieGCLID);
        // console.log("Expiry date: ", this.expiryDate);
      }
      if (this.cookieFBCLID != null) {
        this.cookieService.set('fbclid', this.cookieFBCLID, { expires: this.expiryDate, path: '/' });
        // console.log("Facebook Cookie: ", this.cookieFBCLID);
      }
      if (!userIdExist) {
        // alert("User not found!");
        // this.cookieService.set('kubona_shopper', this.generateRandomUserId(), { expires: this.expiryDate, path: '/' })
      }
    });
  }

  sendClickEvent(eventLabel: string) {
    //this.googleService.eventEmitter("links", "breadcrumb_nav", eventLabel, 0);
    this.googleService.homepageEventEmitter("links", "breadcrumb_nav", eventLabel);
  }

  get userID(): string {
    let id = this.cookieService.get('kubona_shopper');
    this.userId = id;
    return this.userId as string;
  }

  checkNetworkStatus() {
    this.networkStatus = navigator.onLine;
    this.networkStatus$ = merge(
      of(null),
      fromEvent(window, 'online'),
      fromEvent(window, 'offline')
    )
      .pipe(map(() => navigator.onLine))
      .subscribe(status => {
        console.log('status', status);
        this.networkStatus = status;
      });
  }

  // generateRandomUserId() {
  //   const uuid = [];
  //   const characters = 'abcdef0123456789';
  //   const hyphenPositions = [8, 13, 18, 23];

  //   for (let i = 0; i < 36; i++) {
  //     if (hyphenPositions.includes(i)) {
  //       uuid.push('-');
  //     } else {
  //       const randomIndex = Math.floor(Math.random() * characters.length);
  //       uuid.push(characters[randomIndex]);
  //     }
  //   }
  //   return uuid.join('');
  // }
}
