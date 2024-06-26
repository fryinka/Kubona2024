import { Component, OnInit } from '@angular/core';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-how-to-check-size',
  templateUrl: './how-to-check-size.component.html',
  styleUrls: ['./how-to-check-size.component.css']
})
export class HowToCheckSizeComponent implements OnInit {

  constructor(private seoService:SEOService) { }

  ngOnInit(): void {
    this.seoService.updateDescription('How to check your size');
    this.seoService.updateTitle('How to check your size - Kubona - Premium Italian Leather Shoes.');
  }

}
