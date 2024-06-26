import { Component } from '@angular/core';
import { Cartlist } from '../models/order.model';
import { DepartmentGroup, RecentlyViewed } from '../models/prod-list';
import { OrderService } from '../services/order.service';
import { ProductService } from '../services/product.service';
import { SpinnerService } from '../services/spinner.service';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public totalCartItems: number = 0;
  cartlist: Cartlist[] = [];
  private pageIndex: number = 0;
  private pageSize: number = 200;
  mnsubCat: DepartmentGroup[];
  wnsubCat: DepartmentGroup[];
  assubCat: DepartmentGroup[];
  recentlyViewed: RecentlyViewed[]=[];
  recentSize:number=15;
  badgeCounter$:number;
  
  constructor(private orderService: OrderService, private productService:ProductService, private badgeCounter:SpinnerService){}

  ngOnInit(): void {
    this.orderService.getCartItems<Cartlist>(this.pageIndex, this.pageSize)
      .subscribe(result => {
        this.cartlist = result;
    })
    this.badgeCounter.badgeCounter$.subscribe(res=>{this.badgeCounter$ = res.valueOf()});
    this.productService.getDepartmentGroupBy<DepartmentGroup>('70610').subscribe(response=>{
          this.mnsubCat = response;
           })
    this.productService.getDepartmentGroupBy<DepartmentGroup>('70710').subscribe(response=>{
          this.wnsubCat = response;
        })
    this.productService.getDepartmentGroupBy<DepartmentGroup>('70340').subscribe(response=>{
          this.assubCat = response;
        });
    this.productService.getRecentlyViewed<RecentlyViewed>(this.recentSize).subscribe(response=>{this.recentlyViewed=response});
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
