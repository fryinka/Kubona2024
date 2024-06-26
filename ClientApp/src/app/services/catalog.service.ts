import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { CatalogSummary } from '../models/catalog.model';

@Injectable(
  {
    providedIn: 'root'
  })
export class CatalogService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  getCatalog<CatalogSummary>(pageSize: number): Observable<CatalogSummary> {

    var url = this.baseUrl + 'api/Catalog/5';
    

    return this.http.get<CatalogSummary>(url);

  }
  updateIndex(){
    var url = this.baseUrl + 'api/Search';
    return this.http.get(url);
  }

}
