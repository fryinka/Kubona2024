import { HttpClient } from '@angular/common/http';
import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Reviews } from '../models/prod-list';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { ReviewService } from '../services/review.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit,OnChanges {
  @Input() productId: Observable<any>;
  public reviews: Reviews[] = [];
  public reviewArr: Reviews[] = [];
  public averageRating: number = 0;
  public totalRating: number = 0;
  public pageIndex: number = 0;
  public pageSize: number = 8;
  public grandSize: number = 2000;
  //public arrayLength: number = 0;
  
  constructor(private reviewService:ReviewService, private googleService:GoogleAnalyticsService) { }
  ngOnInit(): void {
    
  }
  ngOnChanges(changes) {
    if (changes.productId) {
        this.reviewService.getReviews(Number(changes.productId.currentValue),this.pageIndex,this.grandSize).subscribe((response:any)=>{
          this.reviews = response;
          //this.arrayLength = this.reviewArr.length > this.pageSize ? this.pageSize : this.reviewArr.length;
          //this.reviews = this.reviewArr.splice(this.pageIndex, this.arrayLength);
          // console.log("Reviews: ",this.reviews);
          this.calcRating();
        });  
    }
  }
  calcRating(){
    this.totalRating = 0;
    this.averageRating = 0;
    for (var i = 0; i < this.reviews.length; i++) {
      this.totalRating = this.totalRating + this.reviews[i].rating;
    }
    this.averageRating = this.totalRating / this.reviews.length;
  }

  sendReviewFocusEvent(eventLabel: string, eventValue: number) {
    this.googleService.eventEmitter("reviews", "product_detail", eventLabel, eventValue);
  }
  
}
