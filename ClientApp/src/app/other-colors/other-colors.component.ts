import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { OtherColors } from '../models/prod-list';
import { ProductService } from '../services/product.service';
import { Observable } from 'rxjs';
import { GoogleAnalyticsService } from '../services/google-analytics.service';


@Component({
  selector: 'other-colors',
  templateUrl: './other-colors.component.html',
  styleUrls: ['./other-colors.component.css']
})
export class OtherColorsComponent implements OnInit, OnChanges {

  @Input() productId: Observable<any>;
  @Input() similarId: string;
  public otherColors: OtherColors[]= [];
  public changes: SimpleChanges;


  constructor(private productService: ProductService, private googleService: GoogleAnalyticsService) {

  }


  ngOnInit() {

    //this.productService.getOtherColors<OtherColors>(this.similarId,this.productId)
    //  .subscribe(result => { this.otherColors = result; }, error => console.error(error));

  }

  sendItemClickEvent(eventLabel: string, eventValue: number) {
    this.googleService.eventEmitter("other_colors", "product_detail", eventLabel, eventValue);
  }

  ngOnChanges(changes) {
    if (changes.productId) {
      if (changes.similarId) {
        this.similarId = changes.similarId.currentValue;
      }
      this.productService.getOtherColors<OtherColors>(this.similarId,Number(changes.productId.currentValue))
        .subscribe(result => { this.otherColors = result; }, error => console.error(error));
    }
  }

}
