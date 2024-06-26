import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { CuratedForCust, CustDetails } from '../models/prod-list';
import { RecommendationService } from '../services/recommendation.service';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-curated-for-customer',
  templateUrl: './curated-for-customer.component.html',
  styleUrls: ['./curated-for-customer.component.css']
})
export class CuratedForCustomerComponent implements OnInit {

  public customerDetails: CustDetails;
  public curatedList: CuratedForCust[] = [];
  public date = new Date();
  constructor(private activatedRoute: ActivatedRoute, private recommendService: RecommendationService,private seoService:SEOService) { }
  ngOnInit(): void {
      this.seoService.updateDescription('Personal Recommendations');
      this.seoService.updateTitle('Personal Recommendations - Kubona - Premium Italian Leather Shoes.');    
    this.activatedRoute.paramMap.pipe(
      switchMap((params: ParamMap) => this.recommendService.getCustDetails(params.get('curationId'))
      )
    ).subscribe(result => { this.customerDetails = result; }, error => console.error(error));
    this.activatedRoute.paramMap.pipe(
      switchMap((params: ParamMap) => this.recommendService.getCuratedList(params.get('curationId'), 15)
      )
    ).subscribe(result => { this.curatedList = result; }, error => console.error(error));
  }

  public buildDestinationUrl(title: string, prodId: number) {
    var dest = title.trim().replace(/\s+/g, '-').toLowerCase();
    var final = prodId.toString() + '-' + dest;
    return final;
  }

}
