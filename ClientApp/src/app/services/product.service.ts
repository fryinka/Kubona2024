import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { delay, Observable } from 'rxjs';
import { Prodlist, DepartmentGroup, CategoryTitle, SizeGroup, ProductImages, RecentlyViewed, ColorsGroup, StylesGroup, OtherColors, MenuLinks, RelatedProducts, Sizelist, HeelHeight } from '../models/prod-list';
@Injectable(
  {
    providedIn: 'root'
  })
export class ProductService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getProducts<Prodlist>(urlId: string, lowerPrice: number, upperPrice: number, sortId: number, pageIndex: number, pageSize: number): Observable<Prodlist[]> {

    var url = this.baseUrl + 'api/Product/Products/' + urlId;
    var params = new HttpParams()
      .set("lowerPrice", lowerPrice.toString())
      .set("upperPrice", upperPrice.toString())
      .set("sortId", sortId.toString())
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())

    return this.http.get<Prodlist[]>(url, { params });



  }

  getProduct<Prodlist>(productId: string): Observable<Prodlist> {

    var url = this.baseUrl + 'api/Product/'+productId;
    return this.http.get<Prodlist>(url);

  }

  getCategoryTitle<CategoryTitle>(urlId: string): Observable<CategoryTitle> {

    var url = this.baseUrl + 'api/CategoryTitle/' + urlId;
    return this.http.get<CategoryTitle>(url);

  }

  insertRecentlyViewed(Id: string): Observable<any> {
    var productId: number = 0;
    var idstring: string[];
    if (Id) {

      idstring = Id.split('-');
      if (idstring.length > 0) {
        productId = Number(idstring[0]);
      }
    }

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const headers = { 'content-type': 'application/json' };
   
    var url = this.baseUrl + 'api/RecentlyViewed';

    return this.http.post<any>(url, { "itemId": productId, "numOfViews":1 }, { 'headers': headers });
  }

  getDepartmentGroupBy<DepartmentGroup>(urlId: string): Observable<DepartmentGroup[]> {

    var url = this.baseUrl + 'api/DepartmentGroupBy';
    var params = new HttpParams()
      .set("urlId", urlId)
     

    return this.http.get<DepartmentGroup[]>(url,{params});

  }

  getSizingGroupBy<SizeGroup>(urlId: string): Observable<SizeGroup[]> {

    var url = this.baseUrl + 'api/SizingGroupBy/'+urlId;
    // var params = new HttpParams()
    //   .set("urlId", urlId)


    return this.http.get<SizeGroup[]>(url);

  }


  getColorGroupBy<ColorsGroup>(urlId: string): Observable<ColorsGroup[]> {

    var url = this.baseUrl + 'api/ColorsGroupBy/' + urlId;
    // var params = new HttpParams()
    //   .set("urlId", urlId)


    return this.http.get<ColorsGroup[]>(url);

  }

  getStyleGroupBy<StylesGroup>(urlId: string): Observable<StylesGroup[]> {

    var url = this.baseUrl + 'api/StylesGroupBy/' + urlId;
    // var params = new HttpParams()
    //   .set("urlId", urlId)


    return this.http.get<StylesGroup[]>(url);

  }
  getHeelGroupBy<HeelHeightGroup>(urlId: string): Observable<HeelHeightGroup[]> {
    var url = this.baseUrl + 'api/HeelHeightGroupBy/' + urlId;
    // var params = new HttpParams()
    //   .set("urlId", urlId)
    return this.http.get<HeelHeightGroup[]>(url);
  }
  geMaterialGroupBy<MaterialGroup>(urlId: string): Observable<MaterialGroup[]> {
    var url = this.baseUrl + 'api/MaterialGroupBy/' + urlId;
    // var params = new HttpParams()
    //   .set("urlId", urlId)
    return this.http.get<MaterialGroup[]>(url);
  }

  // getPriceRange<PriceRange>(urlId: string): Observable<PriceRange[]> {

  //   var url = this.baseUrl + 'api/PriceRange';
  //   var params = new HttpParams()
  //     .set("urlId", urlId);
  //   return this.http.get<PriceRange[]>(url, { params });

  // }

  getProductImages<ProductImages>(productId: string): Observable<ProductImages[]> {

    var url = this.baseUrl + 'api/ProductImages';
    var params = new HttpParams()
      .set("Id", productId)


    return this.http.get<ProductImages[]>(url, { params });

  }

  getProductSizes<Sizelist>(productId: string): Observable<Sizelist[]> {

    var url = this.baseUrl + 'api/Product/Sizes/'+ productId;
    return this.http.get<Sizelist[]>(url);
  }

  getOtherColors<OtherColors>(similarId: string, productId: number): Observable<OtherColors[]> {
    var url = this.baseUrl + 'api/OtherColors';
    var params = new HttpParams()
      .set("similarId", similarId)
      .set("productId", productId.toString())


    return this.http.get<OtherColors[]>(url, { params });

  }

  getOtherProdColors<OtherColors>(similarId: string): Observable<OtherColors[]> {
    var url = this.baseUrl + 'api/OtherColors/ProdColors';
    var params = new HttpParams().set("similarId", similarId);
    return this.http.get<OtherColors[]>(url, { params });
  }


  getMenuLinks<MenuLinks>(departmentId: number, categoryId: number, pageSize: number): Observable<MenuLinks[]> {

    var url = this.baseUrl + 'api/TfMenuLinks';
    var params = new HttpParams()
      .set("departmentId", departmentId.toString())
      .set("categoryId", categoryId.toString())
      .set("pageSize", pageSize.toString())


    return this.http.get<MenuLinks[]>(url, { params });

  }

  getRelatedProducts<RelatedProducts>(departmentId: number, itemGroupId: number, pageSize: number): Observable<RelatedProducts[]> {

    var url = this.baseUrl + 'api/RelatedProducts';
    var params = new HttpParams()
      .set("departmentId", departmentId.toString())
      .set("itemGroupId", itemGroupId.toString())
      .set("pageSize", pageSize.toString())


    return this.http.get<RelatedProducts[]>(url, { params });

  }

  getRecentlyViewed<RecentlyViewed>(pageSize: number): Observable<RecentlyViewed[]> {

    var url = this.baseUrl + 'api/RecentlyViewed';
    var params = new HttpParams()
      .set("pageSize", pageSize.toString())


    return this.http.get<RecentlyViewed[]>(url, { params });

  }

  getSearchResult<Prodlist>(searchTerm:string):Observable<Prodlist[]>{
    var url = this.baseUrl + 'api/Search/Search';
    var params = new HttpParams()
      .set("searchTerm", searchTerm)
    return this.http.get<Prodlist[]>(url, { params });
  }

  //Get heelHeight list
  getHeels(): Observable <HeelHeight[] > {
    var url = this.baseUrl + "api/Product/GetHeels/";
    return this.http.get<HeelHeight[]>(url);
  }
  //Change items heel
  updateHeels(productIds: string, heelHeight: number) {
    var url = this.baseUrl + "api/Product/ChangeHeel/" + productIds + "/" + heelHeight;
    return this.http.get(url);
  }

  //Get placeholder products
  getSample(): Observable<any[]> {
    return this.http.get<any[]>('/assets/data.json');
  }
}


