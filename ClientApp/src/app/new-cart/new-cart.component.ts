import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";
import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { BehaviorSubject } from "rxjs/internal/BehaviorSubject";
import { Cartlist, ActiveOrder } from "../models/order.model";
import { HeelHeight } from "../models/prod-list";
import { FacebookEventService } from "../services/facebook-events.service";
import { GoogleAnalyticsService } from "../services/google-analytics.service";
import { OrderService } from "../services/order.service";
import { ProductService } from "../services/product.service";
import { SEOService } from "../services/seo.service";
import { SpinnerService } from "../services/spinner.service";

@Component({
  selector: "new-cart",
  templateUrl: "./new-cart.component.html",
  styleUrls: ["./new-cart.component.css"],
})
export class NewCartComponent implements OnInit {
  public cartlist: Cartlist[] = [];
  public heelList: HeelHeight[] = [];
  public productIds: string = '';
  public isUpdated: any;
  public heelHeight: number;
  public heelChoice: number;
  public activeOrder: ActiveOrder;
  public whatAppUrl: string = null;
  private pageIndex: number = 0;
  private pageSize: number = 200;
  public orderId: number = 0;
  public orderItemId: number = 0;
  public phoneNumber: string = "";
  public total: number = 0;
  public source: string = "";
  public cartForm: FormGroup;
  public isValidFormSubmitted: boolean;
  public Error: string = "";
  public submitted: boolean = false;
  public g_clid: string = '';
  public fb_clid: string = '';
  public qty: number = 0;
  private _orderCount = new BehaviorSubject<Cartlist[]>([]);
  private _orderCount$ = this._orderCount.asObservable();
  constructor(private orderService: OrderService, private breakpointObserver: BreakpointObserver, private router: Router, private builder: FormBuilder, private googleService: GoogleAnalyticsService, private facebookService: FacebookEventService, private seoService: SEOService, private badgeCounter: SpinnerService, private cookieService: CookieService, private productService: ProductService) { }


  ngOnInit() {
   const cookieGExists: boolean = this.cookieService.check('gclid');
   const cookieFBExists: boolean = this.cookieService.check('fbclid');
   if (cookieGExists){
     this.g_clid = this.cookieService.get('gclid');
    //  console.log("Cookie for the order: ", this.g_clid);
   }
   if (cookieFBExists){
     this.fb_clid = this.cookieService.get('fbclid');
    //  console.log("FB for the order: ", this.fb_clid);
   }
   this.cartForm = this.builder.group({
     gsm: ["", [Validators.required, Validators.pattern("^((\\+234-?)|0)?[0-9]{11}$"), Validators.maxLength(11),],],
     gclid: [this.g_clid],
     fbclid:[this.fb_clid]
   });
   this.seoService.updateDescription("Submit via WhatsApp");
   this.seoService.updateTitle("Submit via WhatsApp - Kubona - Premium Italian Leather Shoes.");
   this.orderService.getCartItems(this.pageIndex, this.pageSize).subscribe((result:any) => {
     this.cartlist = result;
     // this._orderCount.next(this.cartlist);
    //  console.log(this.cartlist);
     // console.log(this._orderCount$);
     if (this.cartlist.length > 0) {
       for (let i = 0; i < this.cartlist.length; i++) {
         this.total = this.total + this.cartlist[i].internetPrice * this.cartlist[i].quantity;
         this.qty = this.cartlist[i].quantity;
       }

     } else if (this.cartlist.length <= 0) {
       this.router.navigate(["/"]);
     }

   }, (error) => console.error(error)
   );

   //Need to get orderId and only retrieve cart if orderId > 0
   this.orderService.getActiveOrder<ActiveOrder>().subscribe((result) => {
     this.activeOrder = result;
     this.orderId = this.activeOrder.orderId;
     //this.total = this.activeOrder.totalValue;
   }, (error) => console.error(error)
   );
   this.setBrowserSource();
  }
  // ngOnInit() {
  //   this.getHeels();
  // }
  get f() {
    return this.cartForm.controls;
  }

//   completeOrder() {
//     this.submitted = true;
//     this.phoneNumber = this.cartForm.controls["gsm"].value;
//     let gclid = this.cartForm.controls["gclid"].value;
//     let fbclid = this.cartForm.controls["fbclid"].value;
//     // console.log(this.cartForm.value);
//     if (this.cartForm.invalid) {
//       this.Error = "PLEASE ENTER YOUR WHATSAPP NUMBER!";
//     } else if (this.cartForm.valid) {
//       this.orderService.checkoutOrder(this.source, this.phoneNumber, this.total, gclid, fbclid).subscribe((result) => {
//         this.whatAppUrl = result.whatsAppUrl;
//         this.facebookService.initiateCheckout(this.total, this.orderId);
//         this.googleService.eventEmitter("begin_checkout", "funnel", this.orderId.toString(), this.total);
//         this.googleService.reportConversion("https://www.kubona.ng/whatsapp", this.total);
//         if (this.whatAppUrl != null) {
//           //window.location.href = this.whatAppUrl;
//           this.router.navigate(["/externalRedirect", { externalUrl: this.whatAppUrl },]);
//         }
//       }, (error) => console.error(error)
//       );
//       this.badgeCounter.resetCounter();
//       // this.cartService.updateCart(this.cartlist);
//     }
//   }

  deleteItemInCart(cartItemId) {
    this.orderItemId = cartItemId;
    let index = this.cartlist.findIndex((response) => response.orderItemId === this.orderItemId);
    this.cartlist.splice(index, 1);
    this.orderService.removeSingleItem(this.orderItemId).subscribe((response) => console.log("Delete Successful!", response), (error) => console.log("There was an error!", error));
    if (this.cartlist.length > 0) {
      this.total = 0;
      for (let i = 0; i < this.cartlist.length; i++) {
        this.total = this.total + this.cartlist[i].internetPrice * this.cartlist[i].quantity;
      }
      // this.cartService.updateCart(this.cartlist);
    }
    if (this.cartlist.length <= 0) {
      this.router.navigate(["/"]);
      this.badgeCounter.resetCounter();
    }
    this.badgeCounter.decreaseCounter();
    this._orderCount.next(this.cartlist);
  }

  setBrowserSource() {
    this.breakpointObserver.observe([Breakpoints.Handset, Breakpoints.Tablet, Breakpoints.Web]).subscribe((result) => {
      if (result.matches) {
        if (result.breakpoints["(max-width: 599.98px) and (orientation: portrait)"] || result.breakpoints["(max-width: 599.98px) and (orientation: landscape)"]) {
          this.source = "Mobile";
        } else if (result.breakpoints["(min-width: 1280px) and (orientation: portrait)"] || result.breakpoints["(min-width: 1280px) and (orientation: landscape)"]) {
          this.source = "Desktop";
        } else {
          this.source = "Tablet";
        }
      }
    });
  }

  increaseQty() {
    this.qty++;
  }
  decreaseQty(cartItemId) {
    this.qty--;
    if (this.qty <= 0) {
      this.deleteItemInCart(cartItemId);
    }
  }

  getHeel(event: any) {
    this.heelHeight = event.target.value;
    // console.log(this.heelHeight);
  }
  //get department name
  getHeels() {
    this.productService.getHeels().subscribe(response => {
      this.heelList = response;
      // console.log(this.heelList);
    }, error => console.log(error));

  }
  //update items department TODO: ensure it returns the right thing
  updateHeelHeight() {
    // this.heelHeight = this.heelChoice;
    // console.log("Product Ids: " + this.productIds);
    this.productService.updateHeels(this.productIds, this.heelHeight).subscribe((response) => {
      this.isUpdated = response;
    }, error => console.log(error));

  }
}
