import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Cartlist, ActiveOrder, CheckoutData } from '../models/order.model';

@Injectable(
  {
    providedIn: 'root'
  })
export class OrderService {
  private _orderCount = new BehaviorSubject<Cartlist[]>([]);
  private _orderCount$ = this._orderCount.asObservable();
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getCartItems<Cartlist>(pageNumber: number, pageSize: number): Observable<Cartlist[]> {

    var url = this.baseUrl + 'api/Order';
    var params = new HttpParams()
    .set("pageNumber", pageNumber.toString())
    .set("pageSize", pageSize.toString())
    
    return this.http.get<Cartlist[]>(url, { params });
  }
  
  getSizeCode(trackingId: string){
    var url = this.baseUrl + 'api/Order/GetSizeId/' + trackingId ;
    return this.http.get(url);
  }

  getCustomerHistory(phonenumber: string): Observable<any[]> {
    var url = this.baseUrl + 'api/RecentlyViewed/CustomerLookup/' + phonenumber;
    return this.http.get<any[]>(url);
  }

  insertItemIntoOrder(productId: number, itemgroupSizeId: number): Observable<any> {


    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const headers = { 'content-type': 'application/json' };

    var url = this.baseUrl + 'api/Order';

    return this.http.post<any>(url, { "productId": productId, "itemgroupSizeId": itemgroupSizeId }, { 'headers': headers });
  }

  // deleteItemInCart(cartItemId: number) {
  //   if (window.confirm('Are you sure you want to delete the item?')) {
  //     this.cartlist.splice(cartItemId, 1);
  //   }
  // }


  removeSingleItem(cartItemId): Observable<any> {
      var url = this.baseUrl + 'api/CartManage';
    if (window.confirm('Are you sure you want to delete the item?')) {
          return this.http.get(`${url}/${cartItemId}`);
        } else {return null}
      }
    

  //remove all items in cart
  emptyCart() {
    
  }






  getActiveOrder<ActiveOrder>(): Observable<ActiveOrder> {

    var url = this.baseUrl + 'api/Order/ActiveOrder';
    return this.http.get<ActiveOrder>(url);


  }

  checkout(source: string, customerGSM: string, total: number){


    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const headers = { 'content-type': 'application/json' };

    var url = this.baseUrl + 'api/CheckOut';

    return this.http.post<CheckoutData>(url, { "source": source, "customerGSM": customerGSM, "total": total}, { 'headers': headers });

    
  }

  checkoutOrder(source: string, customerGSM: string, total: number, gclid: string, fbclid: string, exist: boolean, paymentOption:number) {
    var url = this.baseUrl + 'api/CheckOut';
    const headers = { 'content-type': 'application/json' };
    const body = { source: source, customerGSM: customerGSM, total: total, gclid: gclid, fbclid: fbclid, exist: exist, paymentOption: paymentOption }
    return this.http.post<CheckoutData>(url, body, { headers: headers });
  }
  
  checkExisting(gsm:string){
    var url=this.baseUrl + 'api/CheckOut/Existing';
    var params = new HttpParams()
      .set("customerGsm", gsm)
    return this.http.get(url,{params:params});
  }

  verifyProcess(orderId: number, total: number, amountEntered: number, correct: boolean) {
    const headers = { 'content-type': 'application/json' };
    var url = this.baseUrl + 'api/CheckOut/Verify';
    var body = {orderId:orderId,orderAmt:total,amountEntered:amountEntered,correct:correct};
    return this.http.post(url, body,{ headers:headers });
  }

  getOrderInfo(){
    var url=this.baseUrl + 'api/CheckOut/GetOrderInfo';
    return this.http.get(url);
  }

  verifyWhatsApp(phoneNumber:string){
    var url=this.baseUrl + 'api/CheckOut/WhatsApp';
    var params = new HttpParams()
      .set("phone", phoneNumber)
    return this.http.get(url,{params:params});
  }

}
