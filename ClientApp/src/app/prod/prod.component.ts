import { Component, Input, OnInit } from '@angular/core';
import { OtherColors, Prodlist } from '../models/prod-list';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'single-prod',
  templateUrl: './prod.component.html',
  styleUrls: ['./prod.component.css']
})
export class ProdComponent implements OnInit {
 @Input() Prodlist:Prodlist;
 otherColors:any[]=[];
  constructor(private googleService:GoogleAnalyticsService, private productService:ProductService) { }

  ngOnInit(): void {
    this.productService.getOtherColors(this.Prodlist.similarId,this.Prodlist.itemGroupId).subscribe(response=>{
      this.otherColors=response;
    })
  }
  sendProductClickEvent(eventLabel: string) {
    //this.googleService.eventEmitter("product_view", "search_page", eventLabel, 0);
    this.googleService.prodlistEventEmitter("product_view", "search_page", eventLabel);
  }
}
