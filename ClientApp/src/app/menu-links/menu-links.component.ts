import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { MenuLinks } from '../models/prod-list';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Observable } from 'rxjs';
import { GoogleAnalyticsService } from '../services/google-analytics.service';

@Component({
  selector: 'menu-links',
  templateUrl: './menu-links.component.html',
  styleUrls: ['./menu-links.component.css']
})
export class MenuLinksComponent implements OnInit, OnChanges {

  @Input() departmentId: Observable<any>;
  public menulinks: MenuLinks[];
  public changes: SimpleChanges;
  public pageSize: number = 8;


  constructor(private productService: ProductService, private googleService: GoogleAnalyticsService) {

  }

  sendItemClickEvent(eventLabel: string) {
    //this.googleService.eventEmitter("suggested_links", "product_detail", eventLabel, 0);
    this.googleService.prodReviewEventEmitter("suggested_links", eventLabel, "product_detail");
  }

  ngOnInit() {

   

  }

  ngOnChanges(changes) {
    if (changes.departmentId) {
      this.productService.getMenuLinks<MenuLinks>(Number(changes.departmentId.currentValue),0,this.pageSize)
        .subscribe(result => { this.menulinks = result; }, error => console.error(error));
    }
  }

}
