
import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Prodlist, DepartmentGroup, SizeGroup, ColorsGroup, StylesGroup, IComplexItem, CategoryTitle, HeelHeightGroup, MaterialGroup, PriceRange } from '../models/prod-list';
import { ActivatedRoute, BaseRouteReuseStrategy, ParamMap, Router, NavigationEnd, RouterEvent } from '@angular/router';
import { ProductService } from '../services/product.service';
import { filter, switchMap } from 'rxjs';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { SEOService } from '../services/seo.service';
import { NgDynamicBreadcrumbService } from 'ng-dynamic-breadcrumb';




@Component({
  selector: 'prod-list',
  templateUrl: './prod-list1.component.html',
  styleUrls: ['./prod-list1.component.css']
})
export class ProdListComponent1 implements OnInit {
  public prodlists: Prodlist[];
  public prodlistsArr: Prodlist[];
  public deptGrplist: DepartmentGroup[];
  public sizeGrplist: SizeGroup[];
  public colorGrplist: ColorsGroup[];
  public styleGrplist: StylesGroup[];
  public heelGrplist: HeelHeightGroup[];
  public materialGrplist: MaterialGroup[];
  public priceRangelist: PriceRange[];
  public urlId: string = '';
  public title: string = '';
  private upperPrice: number = 0;
  private lowerprice: number = 0;
  private sortId: number = 0;
  public userid: string;
  public cols: number = 3;
  public pageIndex: number = 0;
  public pageSize: number = 30;
  public grandSize: number = 2000;
  public arrayLength: number = 0;
  public disableLoadMoreButton: boolean = false;
  selectedStyles: string[] = [];
  selectedStylesMap: Map<string, boolean> = new Map<string, boolean>();
  selectedStyleIndex: number = -1;


  constructor(private productService: ProductService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private activateRoute: ActivatedRoute, private router: Router, private googleService: GoogleAnalyticsService,
    private seoService: SEOService, private ngDynamicBreadcrumbService: NgDynamicBreadcrumbService) {

  }


  ngOnInit() {

    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
      this.productService.getProducts<Prodlist>(params.get('departmentId'), 0, 0, Number(params.get('sortId')), 0, this.grandSize)
    )).subscribe(result => {
      this.prodlistsArr = result;
      this.arrayLength = this.prodlistsArr.length > this.pageSize ? this.pageSize : this.prodlistsArr.length;
      this.disableLoadMoreButton = this.prodlistsArr.length > this.pageSize ? false : true;
      this.pageIndex = 0;
      this.prodlists = this.prodlistsArr.splice(this.pageIndex, this.arrayLength);
    }, error => console.error(error));

    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
      this.productService.getDepartmentGroupBy<DepartmentGroup>(params.get('departmentId'))
    )).subscribe(result => { this.deptGrplist = result; }, error => console.error(error));

    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
      this.productService.getSizingGroupBy<SizeGroup>(params.get('departmentId'))
    )).subscribe(result => { this.sizeGrplist = result; }, error => console.error(error));

    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
      this.productService.getColorGroupBy<ColorsGroup>(params.get('departmentId'))
    )).subscribe(result => { this.colorGrplist = result; }, error => console.error(error));

    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
      this.productService.getStyleGroupBy<StylesGroup>(params.get('departmentId'))
    )).subscribe(result => {
      this.styleGrplist = result;

      // Initialize selectedStylesMap based on existing selection
      this.selectedStylesMap = new Map<string, boolean>(
        this.styleGrplist.map(styleGroup => [styleGroup.styleDesc, false])
      );

      this.selectedStyles.forEach(selectedStyle => {
        if (this.selectedStylesMap.has(selectedStyle)) {
          this.selectedStylesMap.set(selectedStyle, true);
        }
      });
    }, error => console.error(error));
    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
      this.productService.getHeelGroupBy<HeelHeightGroup>(params.get('departmentId'))
    )).subscribe(result => { this.heelGrplist = result; }, error => console.error(error));
    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
      this.productService.geMaterialGroupBy<MaterialGroup>(params.get('departmentId'))
    )).subscribe(result => { this.materialGrplist = result; }, error => console.error(error));

    this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
      this.productService.getCategoryTitle<CategoryTitle>(params.get('departmentId'))
    )).subscribe(result => {
      this.title = result.categoryDesc;
      this.title = this.updateTitle(this.title);
      this.urlId = result.urlId;
      this.seoService.updateTitle('Shop ' + this.title);
      const breadcrumb = { categoryName: this.title };
      this.ngDynamicBreadcrumbService.updateBreadcrumbLabels(breadcrumb);
      this.updateBreadcrumb();
      this.seoService.updateDescription(this.urlId);
    }, error => console.error(error));

    //this.activateRoute.paramMap.pipe(switchMap((params: ParamMap) =>
    //this.productService.getPriceRange<PriceRange>(params.get('departmentId'))
    //)).subscribe(result => { this.priceRangelist = result; }, error => console.error(error)); 


  }

  ngAfterViewInit() {


  }

  sendProductClickEvent(eventLabel: string) {
    //this.googleService.eventEmitter("product_view", "search_page", eventLabel, 0);
    this.googleService.prodlistEventEmitter("product_view", "search_page", eventLabel);
  }

  sendFilterClickEvent(eventLabel: string) {
    //this.googleService.eventEmitter("filter_links", "search_page", eventLabel, 0);
    this.googleService.searchListEventEmitter("filter_links", "search_page", eventLabel);
  }


  public myTrackByFunction(index: number, complexItem: IComplexItem): number {
    return complexItem.uniqueIdentifier;
  }

  btnDetails(itemGroupId: number) {
    this.router.navigateByUrl('product/' + itemGroupId);
  }

  loadMore() {
    //if (this.prodlists.length - 1) {

    let big = this.prodlistsArr.splice(0, this.pageSize);
    if (big.length > 0) {
      let Arr = this.prodlists.concat(big);
      this.prodlists = Arr;
    }
    this.disableLoadMoreButton = this.prodlistsArr.length > 0 ? false : true;
    //this.googleService.eventEmitter("load_more", "search_page", "load_more", 0);
    this.googleService.ga4GenEventEmitter("load_more", "search_page");
    // }
  }

  updateBreadcrumb(): void {
    const breadcrumbs = [
      {
        label: 'Kubona',
        url: '/'
      },
      {
        label: this.title,
        url: ''
      },
    ];
    this.ngDynamicBreadcrumbService.updateBreadcrumb(breadcrumbs);
  }

  updateTitle(title: string) {
    var words = title.split(" ");
    var wordCount = {};
    var duplicateWords = new Set();
    for (var i = 0; i < words.length; i++) {
      if (wordCount[words[i]]) {
        wordCount[words[i]]++;
        duplicateWords.add(words[i]);
      } else {
        wordCount[words[i]] = 1;
      }
    }
    console.log("Word count: ", wordCount)
    for (var i = 0; i < words.length; i++) {
      if (duplicateWords.has(words[i])) {
        words.splice(i, 1);
        break;
      }
    }
    var newStr = words.join(" ");
    return newStr;
  }

  isStyleSelected(styleGroup: StylesGroup): boolean {
    return this.selectedStyles.includes(styleGroup.styleDesc);
  }

  toggleChipSelection(index: number): void {
    if (this.selectedStyleIndex === index) {
      this.selectedStyleIndex = -1;
    } else {
      this.selectedStyleIndex = index;
    }
  }
  displayStyle = "none";
  openPopup() {
    this.displayStyle = this.displayStyle == "none" ? "block" : "none";
  }

}




