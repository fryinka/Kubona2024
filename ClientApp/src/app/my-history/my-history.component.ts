import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RecentlyViewed } from '../models/prod-list';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { ProductService } from '../services/product.service';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-my-history',
  templateUrl: './my-history.component.html',
  styleUrls: ['./my-history.component.css']
})
export class MyHistoryComponent implements OnInit {

  public pageSize: number = 15;
  public recentlyViewed: RecentlyViewed[];


  constructor(private productService: ProductService, private router:Router, private seoService: SEOService, private googleService: GoogleAnalyticsService) {

  }

  sendItemClickEvent(eventLabel: string, eventValue: number) {
    this.googleService.eventEmitter("recommended", "product_detail", eventLabel, eventValue);
  }

  ngOnInit() {
    this.seoService.updateDescription('My Browsing History');
    this.seoService.updateTitle('My Browsing History - Kubona - Premium Italian Leather Shoes.');
    this.productService.getRecentlyViewed<RecentlyViewed>(this.pageSize)
     .subscribe(response => { this.recentlyViewed = response;
    if(this.recentlyViewed.length<=0){
      this.router.navigate(["/"]);
    }}, error => console.error(error));
  }

  public buildDestinationUrl(title: string, prodId: number) {
    var dest = title.trim().replace(/\s+/g, '-').toLowerCase();
    var final = prodId.toString() + '-' + dest;
    return final;
  }

}
