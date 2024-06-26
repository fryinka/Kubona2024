import { Component, Inject, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { RecentlyViewed } from '../models/prod-list';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Observable } from 'rxjs';
import { GoogleAnalyticsService } from '../services/google-analytics.service';


@Component({
  selector: 'recently-viewed',
  templateUrl: './recently-viewed.component.html',
  styleUrls: ['./recently-viewed.component.css']
})
export class RecentlyViewedComponent implements OnInit, OnChanges {

  @Input() productId: Observable<any>;
  public pageSize: number = 4;
  public recentlyViewed: RecentlyViewed[];
  public changes: SimpleChanges;


  constructor(private productService: ProductService, private activateRoute: ActivatedRoute, private googleService: GoogleAnalyticsService) {

  }

  sendItemClickEvent(eventLabel: string, eventValue: number) {
    //this.googleService.eventEmitter("recently_viewed", "product_detail", eventLabel, eventValue);
    this.googleService.recentlyViewedEventEmitter("recently_viewed", eventLabel, "product_detail", eventValue.toString());
  }

  ngOnInit() {

    //this.productService.getRecentlyViewed<RecentlyViewed>(this.pageSize)
    //  .subscribe(result => { this.recentlyViewed = result; }, error => console.error(error));
  }

  ngOnChanges(changes) {
    if (changes.productId) {
      this.productService.getRecentlyViewed<RecentlyViewed>(this.pageSize)
        .subscribe(result => { this.recentlyViewed = result; }, error => console.error(error));
    }
  }

}
