import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CheckoutData } from '../models/order.model';
import { FacebookEventService } from '../services/facebook-events.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { OrderService } from '../services/order.service';
import { SEOService } from '../services/seo.service';
import { VwoService } from '../services/vwo-service.service';

@Component({
  selector: 'app-verify',
  templateUrl: './verify.component.html',
  styleUrls: ['./verify.component.css']
})
export class VerifyComponent implements OnInit {

  public whatAppUrl: string = null;
  public orderId: number = 0;
  public orderItemId: number = 0;
  public phoneNumber: string = "";
  public total: number = 0;
  public priceForm: FormGroup;
  public price: string = null;
  public Error: string = "";
  public submitted: boolean = false;
  public priceCheck: boolean = false;
  // public whatsapp: boolean = false;
  constructor(private orderService: OrderService, private activatedRoute: ActivatedRoute, private router: Router, private builder: FormBuilder, private googleService: GoogleAnalyticsService, private facebookService: FacebookEventService, private seoService: SEOService, private vwoService: VwoService) {
    this.activatedRoute.queryParamMap.subscribe(queryParams => {
      if (this.router.getCurrentNavigation().extras.state) {
        this.orderId = this.router.getCurrentNavigation().extras.state.orderId;
        this.total = this.router.getCurrentNavigation().extras.state.amount;
        // this.whatsapp = this.router.getCurrentNavigation().extras.state.whatsapp;
      }
    })
  }

  ngOnInit() {
    this.seoService.updateDescription("Verify Customer");
    this.seoService.updateTitle("Verify Customer - Kubona - Premium Italian Leather Shoes.");
    this.priceForm = this.builder.group({
      price: ['']
    });
  }

  get f() {
    return this.priceForm.controls;
  }


  completeOrder() {
    this.submitted = true;
    // let price = this.priceForm.controls["price"].value != null ? this.priceForm.controls["price"].value : 0;
    let price = this.price != null ? this.price : "0";
    // if (this.priceForm.invalid) {
    //   this.Error = "PLEASE CONFIRM THE AMOUNT DUE!";
    // } else if (this.priceForm.valid) {

    price.trim().replace(',', '').replace('.', '').replace('N', '').replace('n', '').replace('-', '').replace(/\D/g, '');
    this.priceCheck = Math.abs(Number(price) - this.total) < 1000 ? true : false;

    this.orderService.verifyProcess(this.orderId, this.total, Number(price), this.priceCheck).subscribe((result: CheckoutData) => {
      this.whatAppUrl = result.whatsAppUrl;
      //if total price entered is correct send purchase
      if (this.priceCheck == true) {
        this.facebookService.initiatePurchase(this.total, this.orderId);
        this.googleService.ga4eventEmitter("purchase", this.orderId.toString(), this.total); //send verified event
      }
      // else if (this.priceCheck == false) {
      //   // this.googleService.ga4eventEmitter("unconfirmed_checkout", this.orderId.toString(), this.total);
      // }
      if (this.whatAppUrl != null) {
        this.router.navigate(["/externalRedirect", { externalUrl: this.whatAppUrl },]);
      }
    }, (error) => console.error(error)
    );
    // }
  }
}

