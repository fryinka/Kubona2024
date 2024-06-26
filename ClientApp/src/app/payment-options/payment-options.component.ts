import { Component, OnInit } from '@angular/core';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-payment-options',
  templateUrl: './payment-options.component.html',
  styleUrls: ['./payment-options.component.css']
})
export class PaymentOptionsComponent implements OnInit {

  constructor(private seoService:SEOService) { }

  ngOnInit(): void {
    this.seoService.updateDescription('Payment Options');
    this.seoService.updateTitle('Payment Options - Kubona - Premium Italian Leather Shoes.');
  }

}
