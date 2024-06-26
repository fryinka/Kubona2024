import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { RelatedProducts } from '../models/prod-list';
import { ProductService } from '../services/product.service';
import { Observable } from 'rxjs';
import { GoogleAnalyticsService } from '../services/google-analytics.service';


@Component({
  selector: 'related-products',
  templateUrl: './related-products.component.html',
  styleUrls: ['./related-products.component.css']
})
export class RelatedProductsComponent implements OnInit, OnChanges {

  @Input() departmentId: number;
  @Input() productId: Observable<any>;
  public pageSize: number = 8;
  public relatedProd: RelatedProducts[];
  public changes: SimpleChanges;
 

  constructor(private productService: ProductService, private googleService: GoogleAnalyticsService) {

  }

  sendItemClickEvent(eventLabel: string, eventValue: number) {
    //this.googleService.eventEmitter("recommended", "product_detail", eventLabel, eventValue);
    this.googleService.recentlyViewedEventEmitter("recommended", eventLabel, "product_detail", eventValue.toString());
  }

  ngOnInit() {
    
   
  }

  ngOnChanges(changes) {
    if (changes.productId) {
      if (changes.departmentId) {
        this.departmentId = Number(changes.departmentId.currentValue);
      }
      this.productService.getRelatedProducts<RelatedProducts>(this.departmentId, Number(changes.productId.currentValue), this.pageSize)
        .subscribe(result => { this.relatedProd = result; }, error => console.error(error));
    }
  }

}
