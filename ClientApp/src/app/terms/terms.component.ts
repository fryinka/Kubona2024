import { Component, OnInit } from '@angular/core';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-terms',
  templateUrl: './terms.component.html',
  styleUrls: ['./terms.component.css']
})
export class TermsComponent implements OnInit {

  constructor(private seoService:SEOService) { }

  ngOnInit(): void {
    this.seoService.updateDescription('Terms of Condition');
    this.seoService.updateTitle('Terms of Condition - Kubona - Premium Italian Leather Shoes.');
  }
}
