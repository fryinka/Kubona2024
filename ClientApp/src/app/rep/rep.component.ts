import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Reviews, Reply } from '../models/prod-list';
import { ReviewService } from '../services/review.service';

@Component({
  selector: 'app-rep',
  templateUrl: './rep.component.html',
  styleUrls: ['./rep.component.css']
})
export class RepComponent implements OnInit, OnChanges {
  @Input() list:Reviews;
  reply:Reply;
  constructor(private reviewService:ReviewService) { }
  ngOnChanges(changes: SimpleChanges): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
    this.reviewService.getResponseByReviewId(this.list.reviewId).subscribe(response=>{
      this.reply=response;
      //console.log(this.reply);
    })
  }

}
