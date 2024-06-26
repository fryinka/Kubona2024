import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {
  GSM: string = '';
  orderHistory: any[] = [];
  constructor(private orderService: OrderService,private seoService: SEOService) { }

  ngOnInit(): void {
    this.seoService.updateDescription('My Order History');
    this.seoService.updateTitle('My Order History - Kubona - Premium Italian Leather Shoes.');
  }
  lookUp() {
    if (this.GSM != null) {
    this.orderService.getCustomerHistory(this.GSM).subscribe(response => {
      this.orderHistory = response;
      //console.log(this.orderHistory);
    }, error => console.log(error));
   }
 }
}
