import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Cartlist } from './models/order.model';
import { OrderService } from './services/order.service';

@Injectable({
  providedIn: 'root'
})
export class CartGuard implements CanActivate {
pageIndex:number = 0; 
pageSize:number = 200;
cartlist:Cartlist[]=[];

  constructor (private cart:OrderService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {

      this.cart.getCartItems<Cartlist>(this.pageIndex, this.pageSize).subscribe((response)=>{this.cartlist=response;});
      if (this.cartlist.length>0){
        return true;
      }
  }
  
}
