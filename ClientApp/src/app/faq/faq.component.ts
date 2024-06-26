import { Component, OnInit } from '@angular/core';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FaqComponent implements OnInit {

  constructor(private seoService:SEOService) { }

  ngOnInit(): void {
    this.seoService.updateDescription('Help');
    this.seoService.updateTitle('Help - Kubona - Premium Italian Leather Shoes.');
  }

}
