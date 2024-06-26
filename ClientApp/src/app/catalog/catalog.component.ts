import { Component, Inject, OnInit } from '@angular/core';
import { CatalogService } from '../services/catalog.service';
import { CatalogSummary } from '../models/catalog.model';



@Component({
  selector: 'catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {

  public pageSize: number = 5;
  public catalogSummary: CatalogSummary = null;

  constructor(private catalogService: CatalogService) {
  }

  ngOnInit() {
    this.catalogService.getCatalog<CatalogSummary>(this.pageSize)
      .subscribe(result => { this.catalogSummary = result; }, error => console.error(error));
  }

}
