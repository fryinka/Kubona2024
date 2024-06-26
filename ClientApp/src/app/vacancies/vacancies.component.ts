import { Component, OnInit } from '@angular/core';
import { SEOService } from '../services/seo.service';

@Component({
  selector: 'app-vacancies',
  templateUrl: './vacancies.component.html',
  styleUrls: ['./vacancies.component.css']
})
export class VacanciesComponent implements OnInit {

  constructor(private seoService:SEOService) { }

  ngOnInit(): void {
    this.seoService.updateDescription('Corporate Careers');
    this.seoService.updateTitle('Corporate Careers - Kubona - Premium Italian Leather Shoes.');
  }

}
