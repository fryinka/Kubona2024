import { Component, Inject,  OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Prodlist, DepartmentGroup, SizeGroup, ColorsGroup, StylesGroup, IComplexItem } from '../models/prod-list';
import { ActivatedRoute, ParamMap, Router} from '@angular/router';
import { ProductService } from '../services/product.service';


@Component({
  selector: 'app-newly-arrived',
  templateUrl: './newly-arrived.component.html',
  styleUrls: ['./newly-arrived.component.css']
})

export class NewlyArrivedComponent implements OnInit {
  public prodlists: Prodlist[];
  public prodlistsArr: Prodlist[];
  public urlId: string = '';
  private upperPrice: number = 0;
  private lowerprice: number = 0;
  private sortId: number = 0;
  public userid: string;
  public cols: number = 3;
  public pageIndex: number = 0;
  public pageSize: number;

  constructor(private productService: ProductService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private activateRoute: ActivatedRoute, private router: Router) {
    
  }


  ngOnInit() {

   this.activateRoute.paramMap.subscribe(
       (segs: ParamMap) => {
         if (segs.get('departmentId')) {
           this.urlId = segs.get('departmentId');
       }
       if (segs.get('sortId')) {
         this.sortId = Number(segs.get('sortId'));
       }
         
        this.getData(this.urlId, this.sortId, this.lowerprice, this.upperPrice);
      }
      
    );
  }

  ngAfterViewInit() { }

  getData(urlId: string, sortId: number, lowerPrice: number, upperPrice: number ) {
    this.productService.getProducts<Prodlist>(urlId,0,0,sortId,this.pageIndex,50)
      .subscribe(result => { this.prodlists = result; }, error => console.error(error));
    this.productService.getProducts<Prodlist>(urlId,0,0,sortId,this.pageIndex,100000)
      .subscribe(result => { this.prodlistsArr = result; }, error => console.error(error));
  }

  public myTrackByFunction(index: number, complexItem: IComplexItem): number {
    return complexItem.uniqueIdentifier;
  }

  btnDetails(itemGroupId: number) {
    this.router.navigateByUrl('product/'+ itemGroupId);
  }


  loadMore() {
    if (this.prodlists.length - 1){
     let big = this.prodlistsArr.splice(51,50);
     if (big.length>0){
       let Arr = this.prodlists.concat(big);
       this.prodlists = Arr;                   
      }
    }
  }
}





