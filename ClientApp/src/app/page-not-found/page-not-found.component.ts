import { Component, OnInit } from '@angular/core';
import { DepartmentGroup } from '../models/prod-list';
import { ProductService } from '../services/product.service';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.css']
})
export class PageNotFoundComponent implements OnInit {

  mnsubCat: DepartmentGroup[];
  wnsubCat: DepartmentGroup[];
  assubCat: DepartmentGroup[];
  
  constructor(private productService:ProductService, private seoService:SEOService){}

  ngOnInit(): void {

    this.seoService.updateDescription('Error 404');
    this.seoService.updateTitle('Error 404 - Kubona - Premium Italian Leather Shoes.');
    
    this.productService.getDepartmentGroupBy<DepartmentGroup>('70610').subscribe(response=>{
          this.mnsubCat = response;
           })
    this.productService.getDepartmentGroupBy<DepartmentGroup>('70710').subscribe(response=>{
          this.wnsubCat = response;
        })
    this.productService.getDepartmentGroupBy<DepartmentGroup>('70340').subscribe(response=>{
          this.assubCat = response;
        })
  }

}
