import { Component, OnInit } from '@angular/core';
import { Cartlist } from '../models/order.model';
import { OrderService } from '../services/order.service';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';
import { GoogleAnalyticsService } from '../services/google-analytics.service';

@Component({
  selector: 'app-cart-recommend',
  templateUrl: './cart-recommend.component.html',
  styleUrls: ['./cart-recommend.component.css']
})
export class CartRecommendComponent implements OnInit {
  public cartlist: Cartlist[] = [];
  public related: any[] = [];
  public dept = 0;
  public prodId = 0;
  public total: number = 0;
  private pageIndex: number = 0;
  private pageSize: number = 200;
  constructor(private orderService: OrderService, private productService: ProductService, private router: Router, private googleService: GoogleAnalyticsService) { }

  ngOnInit(): void {
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
        // this.router.navigate(["/"]);
      }
    }, (error) => console.error(error)
    );
  }

  sendClickEvent(eventLabel: string, eventValue: number) {
    this.googleService.eventEmitter("cart_recommend", "funnel", eventLabel, eventValue);
  }
}
