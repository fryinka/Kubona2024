import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Reply, Reviews } from '../models/prod-list';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  baseUrl= 'https://reviews.kubona.ng/api/productreviews/';
  constructor(private http: HttpClient) { }
  
  getResponseByReviewId(reviewId):Observable<Reply>{
    let url = this.baseUrl + "GetResponseByreviewId/" +reviewId;
    return this.http.get<Reply>(url);
  }

  getReviews(productId: number, pageIndex: number, pageSize: number):Observable<Reviews[]> {
    const products = productId.toString() + ',' + pageIndex.toString() + ',' + pageSize.toString();
    const url = this.baseUrl + "GetProductReview/" + products;
    return this.http.get<Reviews[]>(url);
  }

}
