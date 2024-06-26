import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { OrderService } from "../services/order.service";
import { Cartlist, ActiveOrder } from "../models/order.model";
import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { GoogleAnalyticsService } from "../services/google-analytics.service";
import { FacebookEventService } from "../services/facebook-events.service";
import { SEOService } from "../services/seo.service";
import { SpinnerService } from "../services/spinner.service";
import { CookieService } from "ngx-cookie-service";
import { ProductService } from "../services/product.service";
import { NavigationExtras } from "@angular/router";
import { VwoService } from "../services/vwo-service.service";

@Component({
  selector: "order-cart",
  templateUrl: "./order-cart.component.html",
  styleUrls: ["./order-cart.component.css"],
})
export class OrderCartComponent implements OnInit {
  public cartlist: Cartlist[] = [];
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
  public related: any[] = [];
  public dept = 0;
  public prodId = 0;
  public custExt: boolean = false;
  public whatsappExt: boolean = false;
  // public whatsapp: boolean = false;
  public gclid: string;
  public fbclid: string;
  public verifyNum: string;

  paymentOptions = [
    { value: 100, label: 'I want to pay online now with my Debit/Credit card' },
    { value: 101, label: `I will pay {{total | currency: "₦":"symbol":"3.2"}} on delivery` },
    { value: 102, label: `How much is it? Is it {{total/10 | currency: "₦":"symbol":"3.2"}}? Please assist.` },
    { value: 103, label: 'I need information on something else.' }
  ];

  constructor(private orderService: OrderService, private breakpointObserver: BreakpointObserver, private router: Router, private builder: FormBuilder, private googleService: GoogleAnalyticsService, private facebookService: FacebookEventService, private seoService: SEOService, private badgeCounter: SpinnerService, private cookieService: CookieService, private productService: ProductService, private vwoService: VwoService) { }

  ngOnInit() {
    const cookieGExists: boolean = this.cookieService.check('gclid');
    const cookieFBExists: boolean = this.cookieService.check('fbclid');
    if (cookieGExists) {
      this.g_clid = this.cookieService.get('gclid');
    }
    if (cookieFBExists) {
      this.fb_clid = this.cookieService.get('fbclid');
    }
    this.cartForm = this.builder.group({
      gsm: ['', [Validators.required, Validators.pattern('^0?[7-9]?[0-9]{9}$')]],
      gclid: [this.g_clid],
      fbclid: [this.fb_clid],
      paymentOption: ['', Validators.required]
    });
    this.seoService.updateDescription("Submit via WhatsApp");
    this.seoService.updateTitle("Submit via WhatsApp - Kubona - Premium Italian Leather Shoes.");
    this.orderService.getCartItems<Cartlist>(this.pageIndex, this.pageSize).subscribe((result) => {
      this.cartlist = result;
      this.dept = this.cartlist[Math.floor(Math.random() * this.cartlist.length)].departmentId;
      this.prodId = this.cartlist[Math.floor(Math.random() * this.cartlist.length)].itemGroupId;
      this.productService.getRelatedProducts(this.dept, this.prodId, 6).subscribe(response => {
        this.related = response;
      });
      if (this.cartlist.length > 0) {
        for (let i = 0; i < this.cartlist.length; i++) {
          this.total = this.total + this.cartlist[i].internetPrice * this.cartlist[i].quantity;
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
    }, (error) => console.error(error)
    );
    this.setBrowserSource();
  }

  get f() {
    return this.cartForm.controls;
  }

  completeOrder() {
    this.submitted = true;
    let num = this.cartForm.controls["gsm"].value;
    if (num.length === 10 && !num.startsWith('0')) {
      this.phoneNumber = '0' + num;
    } else
      this.phoneNumber = num;
    let gclid = this.cartForm.controls["gclid"].value;
    let fbclid = this.cartForm.controls["fbclid"].value;
    let paymentOption = this.cartForm.controls["paymentOption"].value; //how the user intend to pay
    if (this.cartForm.invalid) {
      this.Error = "PLEASE ENTER YOUR WHATSAPP NUMBER!";
    } else if (this.cartForm.valid) {
      //this.vwoService.triggerVWOEvent("purchase"); //VWO A/B Testing
      
      //check if customer is an existing customer
      this.orderService.checkExisting(this.phoneNumber).subscribe((response: any) => {
        this.custExt = response;
        // if (this.custExt == true) {
        //   let exist = true;
        this.orderService.checkoutOrder(this.source, this.phoneNumber, this.total, gclid, fbclid, this.custExt, paymentOption).subscribe((result) => {
          this.whatAppUrl = result.whatsAppUrl;
          //send checkout events      
          this.facebookService.initiateCheckout(this.total, this.orderId);
          this.googleService.ga4eventEmitter("begin_checkout", this.orderId.toString(), this.total);
          this.googleService.reportConversion("https://www.kubona.ng/whatsapp", this.total);
          this.googleService.checkoutRadioEventEmitter("checkoutRadio", this.orderId.toString(), paymentOption.toString());
          if (paymentOption == 101) {
            this.facebookService.initiatePurchase(this.total, this.orderId);
            this.facebookService.initiateLeadGen(this.total, this.orderId);
            this.googleService.ga4eventEmitter("purchase", this.orderId.toString(), this.total);
          }
          if (this.whatAppUrl != null) {
            this.router.navigate(["/externalRedirect", { externalUrl: this.whatAppUrl }]);
            this.badgeCounter.resetCounter();
            // console.log(this.whatAppUrl);
          }
          }, (error) => console.error(error)
          );
        // }
        //else if (this.custExt == false) {
        //  let exist = false
        //  this.orderService.checkoutOrder(this.source, this.phoneNumber, this.total, gclid, fbclid, exist).subscribe((result) => {
        //    this.whatAppUrl = result.whatsAppUrl;
        //  }, (error) => console.error(error));
        //  let navigationExtras: NavigationExtras = {
        //    state: {
        //      orderId: this.orderId,
        //      amount: this.total
        //    },
        //  };
        //  this.googleService.ga4eventEmitter("new_user", this.orderId.toString(), this.total);
        //  this.router.navigate(["/verify"], navigationExtras);
        //};
      });
      this.badgeCounter.resetCounter();
    }
  }

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
    }
    if (this.cartlist.length <= 0) {
      this.router.navigate(["/"]);
      this.badgeCounter.resetCounter();
    }
    this.badgeCounter.decreaseCounter();
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

  sendClickEvent(eventLabel: string, eventValue: number) {
    this.googleService.eventEmitter("cart_recommend", "funnel", eventLabel, eventValue);
  }

  checkExist(gsm: string) {
    this.orderService.checkExisting(gsm).subscribe((response: any) => {
      this.custExt = response;
    });
  }

  radioOption(paymentOption: number, orderId: number) {
    alert(paymentOption + '  ' + orderId);
  }
}
