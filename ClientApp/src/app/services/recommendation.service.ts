import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CuratedForCust, CustDetails } from '../models/prod-list';

@Injectable({
  providedIn: 'root'
})
export class RecommendationService {

  constructor(@Inject('BASE_URL') private baseUrl: string, private http: HttpClient) { }

  public getCustDetails(curationId: string): Observable<CustDetails> {
    var url = this.baseUrl + 'api/SalesCuration/GetCustRecommendation/';
    var params = new HttpParams()
      .set("curationId", curationId.toString())

    return this.http.get<CustDetails>(url, { params });
  }
  public getCuratedList(curationId: string, pageSize: number): Observable<CuratedForCust[]> {
    var url = this.baseUrl + 'api/SalesCuration/CuratedList/';
    var params = new HttpParams()
      .set("curationId", curationId.toString())
      .set("pageSize", pageSize.toString())

    return this.http.get<CuratedForCust[]>(url, { params });
  }
}
