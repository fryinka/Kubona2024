import { Component, OnInit } from '@angular/core';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-delivery-info',
  templateUrl: './delivery-info.component.html',
  styleUrls: ['./delivery-info.component.css']
})
export class DeliveryInfoComponent implements OnInit {

  constructor(private seoService:SEOService) { }

  ngOnInit(): void {
    this.seoService.updateDescription('Shop with confidence');
    this.seoService.updateTitle('Shop with confidence - Kubona - Premium Italian Leather Shoes.');
  }

}
