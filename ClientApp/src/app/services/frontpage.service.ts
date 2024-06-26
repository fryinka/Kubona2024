import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { FrontPageImageRotator } from '../models/frontPageImageRotator';

@Injectable(
  {
    providedIn: 'root'
  })
export class FrontPageService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }



  getFrontPageItems<FrontPageImageRotator>(rotatorId: number, pageSize: number): Observable<FrontPageImageRotator[]> {
    var url = this.baseUrl + 'api/FrontPageImageRotators';
    var params = new HttpParams()
      .set("rotatorId", rotatorId.toString())
      .set("pageSize", pageSize.toString())

    return this.http.get<FrontPageImageRotator[]>(url, { params });



  }


}
