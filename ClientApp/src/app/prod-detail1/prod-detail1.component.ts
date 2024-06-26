import { Component, ViewChild, Inject, OnInit } from '@angular/core';
import { OtherColors, Prodlist, ProductImages, Reviews, Sizelist } from '../models/prod-list';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ProductService } from '../services/product.service';
import { OrderService } from '../services/order.service';
import { switchMap } from 'rxjs/operators';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { FacebookEventService } from '../services/facebook-events.service';
import { SEOService } from '../services/seo.service';
import { SpinnerService } from '../services/spinner.service';
import { CookieService } from 'ngx-cookie-service';
import { ReviewService } from '../services/review.service';
import { NgDynamicBreadcrumbService } from 'ng-dynamic-breadcrumb';
import { VwoService } from '../services/vwo-service.service';

@Component({
  selector: 'app-prod-detail1',
  templateUrl: './prod-detail1.component.html',
  styleUrls: ['./prod-detail1.component.css']
})
export class ProdDetail1Component implements OnInit {

  public prodDetail: Prodlist;
  public productId: number = 0;
  public departmentName: string = null;
  public title: string = null;
  public internetPrice: number = 0;
  public prodImages: ProductImages[];
  public prodSizes: Sizelist[];
  public productSizes: Sizelist[];
  public viewId: number;
  public itemgroupSizeId: number = 0;
  public orderId: number;
  private idstring: string[];
  private isDisabled: boolean = false;
  checkoutForm = new FormControl('', [Validators.required]);
  addToOrderForm: FormGroup;
  Error: string;
  youTubeId: SafeResourceUrl;
  openConverter: boolean = false;
  dropdownUsed: boolean = false;
  dropdownOpened: boolean = false;
  reviews: any[] = [];
  similarId: string = '';
  otherColors: any[] = [];


  constructor(private productService: ProductService, private activateRoute: ActivatedRoute, private orderService: OrderService, private router: Router, private sanitizer: DomSanitizer, private googleService: GoogleAnalyticsService, private facebookService: FacebookEventService, private seoService: SEOService, private badgeCounter: SpinnerService, private cookieService: CookieService, private reviewService: ReviewService, private ngDynamicBreadcrumbService: NgDynamicBreadcrumbService, private formBuilder: FormBuilder, private vwoService: VwoService) { }
  ngOnInit() {
    //checkoutForm
    this.addToOrderForm = this.formBuilder.group({
      color: ['', Validators.required],
      size: ['', Validators.required]
    });
    this.dropdownUsed = false;// reset the dropdown checker
    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) => this.productService.getProduct<Prodlist>(params.get('productId'))
    )
    ).subscribe(result => {
      this.prodDetail = result;
      this.productId = this.prodDetail.itemGroupId;
      this.similarId = this.prodDetail.similarId;
      this.departmentName = this.prodDetail.departmentName;
      this.internetPrice = this.prodDetail.internetPrice;
      this.title = this.prodDetail.title;
      this.googleService.viewContent(this.internetPrice, this.productId, this.departmentName);
      this.facebookService.viewContent(this.internetPrice, this.productId, this.departmentName, this.title);
      this.youTubeId = this.sanitizer.bypassSecurityTrustResourceUrl(this.prodDetail.youTubeId);
      this.seoService.updateDescription(this.title);
      this.seoService.updateTitle('Shop ' + this.title);
      // const breadcrumb = { productName: this.title, categoryName: this.prodDetail.departmentName };
      // this.ngDynamicBreadcrumbService.updateBreadcrumbLabels(breadcrumb);
      // this.updateBreadcrumb();
      this.resetForm();
      this.getOtherColors(this.prodDetail.similarId);

    }, error => console.error(error));

    this.activateRoute.paramMap.pipe(
      switchMap((params: ParamMap) => this.productService.insertRecentlyViewed(params.get('productId'))
      )
    ).subscribe(result => { this.viewId = result; }, error => console.error(error));

    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) => this.productService.getProductImages<ProductImages>(params.get('productId'))
    )).subscribe(result => { this.prodImages = result; }, error => console.error(error));

    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) => this.productService.getProductSizes<Sizelist>(params.get('productId'))
    )).subscribe(result => {
      //get product sizes
      this.prodSizes = result;
      this.productSizes = result;
      if (this.prodSizes.length <= 0) {
        this.addToOrderForm.patchValue({
          size: this.prodDetail.trackingId
        });
      }
    }, error => console.error(error));

    // this.checkReviews();
  }
  // checkReviews() {
  //   setTimeout(() => {
  //     this.reviewService.getReviews(this.prodDetail.itemGroupId, 0, 1).subscribe(result => { this.reviews = result; }, error => console.log(error));
  //   }, 3000);
  // }
  get f() {
    return this.addToOrderForm.controls
  }
  check() {
    this.itemgroupSizeId = this.prodSizes.length > 0 && this.addToOrderForm.controls['size'].valid ? this.addToOrderForm.controls['size'].value : this.itemgroupSizeId; // I added this line
    var productId = this.otherColors.length > 0 && this.addToOrderForm.controls['color'].value != null ? this.addToOrderForm.controls['color'].value : this.productId;
    this.dropdownUsed = productId != this.productId ? true : false; //to check if the dropdown is used.
    if ((this.addToOrderForm.controls['size'].value == null && this.addToOrderForm.invalid) || (this.addToOrderForm.controls['size'].value == null && this.addToOrderForm.controls['color'].value == null)) {
      this.Error = 'PLEASE SELECT AVAILABLE COLOR AND SIZE'
      // if (this.floating){
      this.gotoTop();
      window.alert("Please Select Available Color and Size");
      // }
    } else
      if (this.addToOrderForm.valid && this.addToOrderForm.controls['size'].value != null) {
        if (productId > 0) {
          if (this.itemgroupSizeId >= 0) {
            this.orderService.insertItemIntoOrder(productId, this.itemgroupSizeId)
              .subscribe(result => {
                this.orderId = result;
                if (this.orderId > 0) {
                  this.isDisabled = true;
                  this.facebookService.addToCart(this.internetPrice, productId, this.departmentName, this.title);
                  this.vwoService.triggerVWOEvent("cartadd");
                  if (this.dropdownUsed == true) {
                    //alert("Dropdown used!");
                    //this.googleService.eventEmitter('add_to_cart_color', 'product_detail', productId.toString(), this.internetPrice);
                    this.googleService.addToCartEventEmitter('add_to_cart_color', 'product_detail', productId.toString(), this.internetPrice);
                  }
                  else {
                    //alert("No dropdown used!");
                    //this.googleService.eventEmitter('add_to_cart', 'product_detail', productId.toString(), this.internetPrice);
                    this.googleService.addToCartEventEmitter('add_to_cart', 'product_detail', productId.toString(), this.internetPrice);
                  }
                  this.router.navigate(['whatsapp']);
                }
              }, error => console.error(error));
          }
          this.badgeCounter.increaseCounter();
        }
      }
  }

  resetForm() {
    this.addToOrderForm.reset();
    Object.keys(this.addToOrderForm.controls).forEach(key => {
      this.addToOrderForm.controls[key].setErrors({ 'pristine': true, 'touched': false })
    });
    this.Error = null;
    this.addToOrderForm.markAsPristine({});
    // console.log(this.addToOrderForm.errors)
  }
  // floating='none';
  addProductToOrder() {
    this.itemgroupSizeId = this.checkoutForm.value; // I added this line
    if (this.checkoutForm.invalid) {
      this.Error = 'PLEASE SELECT AN AVAILABLE SIZE'
      // if (this.floating){
      this.gotoTop();
      window.alert("Please Select an Available Size");
      // }
    } else
      if (this.checkoutForm.valid) {

        if (this.productId > 0) {
          if (this.itemgroupSizeId >= 0) {
            this.orderService.insertItemIntoOrder(this.productId, this.itemgroupSizeId)
              .subscribe(result => {
                this.orderId = result;
                if (this.orderId > 0) {
                  this.isDisabled = true;
                  this.facebookService.addToCart(this.internetPrice, this.productId, this.departmentName, this.title);
                  this.googleService.eventEmitter('add_to_cart', 'product_detail', this.productId.toString(), this.internetPrice)
                  this.router.navigate(['whatsapp']);
                }
              }, error => console.error(error));
          }
          this.badgeCounter.increaseCounter();

        }
      }

  }

  //get other product colors
  getOtherColors(similarId: string) {
    this.productService.getOtherProdColors(similarId).subscribe(response => {
      this.otherColors = response;
      //console.log(this.otherColors);
      if (this.otherColors.length <= 1) {
        this.addToOrderForm.patchValue({
          color: this.productId,
        })
      }
      else if (this.otherColors.length > 1) {
        this.resetForm();
        this.addToOrderForm.patchValue({
          color: null,
          size: null
        })
      }
    });
    // console.log(this.addToOrderForm.value);
  }

  //fetch product sizes
  getProdSizes(productId: number) {
    this.addToOrderForm.patchValue({
      size: null
    })
    this.productService.getProductSizes(productId.toString()).subscribe((result: Sizelist[]) => {
      this.prodSizes = result;
      // console.log(this.addToOrderForm.value);
    });
  }

  // updateBreadcrumb(): void {
  //   const breadcrumbs = [
  //     {
  //       label: 'Kubona',
  //       url: '/'
  //     },
  //     {
  //       label: this.prodDetail.departmentName,
  //       url: 'category/' + this.prodDetail.departmentId + '-' + this.prodDetail.departmentName.split(' ').join('-')
  //     },
  //     {
  //       label: this.title,
  //       url: ''
  //     }
  //   ];
  //   this.ngDynamicBreadcrumbService.updateBreadcrumb(breadcrumbs);
  // }
  //to track if product reviews are read by users
  sendReviewFocusEvent(eventLabel: string, eventValue: number) {
    //this.googleService.eventEmitter("review_viewed", "product_detail", eventLabel, eventValue);
    this.googleService.prodReviewEventEmitter("review_viewed", "product_detail", eventLabel);
  }

  sizeConverter() {
    this.openConverter = true;
  }

  displayStyle = "none";

  openPopup() {
    this.displayStyle = "block";
    //this.googleService.eventEmitter("size_converter", "product_detail", "size_converter", 0);
    this.googleService.ga4GenEventEmitter("size_converter", "product_detail");
  }
  closePopup() {
    this.displayStyle = "none";
  }

  gotoTop() {
    window.scroll({
      top: 500,
      left: 0,
      behavior: 'smooth'
    });
  }
}

