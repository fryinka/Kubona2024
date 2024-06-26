import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProdDetailComponent } from './prod-detail/prod-detail.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProdListComponent } from './prod-list/prod-list.component';
import { OrderCartComponent } from './order-cart/order-cart.component';
import { AngularMaterialModule } from './angular-material.module';
// import { VirtualScrollerModule } from 'ngx-virtual-scroller';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgImageSliderModule } from 'ng-image-slider';
import { RelatedProductsComponent } from './related-products/related-products.component';
import { OtherColorsComponent } from './other-colors/other-colors.component';
import { MenuLinksComponent } from './menu-links/menu-links.component';
import { RecentlyViewedComponent } from './recently-viewed/recently-viewed.component';
// import { NewlyArrivedComponent } from './newly-arrived/newly-arrived.component';
import { FooterComponent } from './footer/footer.component';
import { AboutComponent } from './about/about.component';
import { ExchangeComponent } from './exchange/exchange.component';
import { ContactComponent } from './contact/contact.component';
import { FaqComponent } from './faq/faq.component';
import { HowItWorksComponent } from './how-it-works/how-it-works.component';
import { DeliveryInfoComponent } from './delivery-info/delivery-info.component';
import { NgDynamicBreadcrumbModule } from 'ng-dynamic-breadcrumb';
import { PrivacyComponent } from './privacy/privacy.component';
import { TermsComponent } from './terms/terms.component';
import { VacanciesComponent } from './vacancies/vacancies.component';
import { PaymentOptionsComponent } from './payment-options/payment-options.component';
import { GoogleAnalyticsService } from './services/google-analytics.service';
import { FacebookEventService } from './services/facebook-events.service';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CatalogComponent } from './catalog/catalog.component';
import { ApiCallsInterceptor } from './api-calls.interceptor';
import { CartGuard } from './cart.guard';
import { LowerCaseUrlSerializer } from './services/UrlSerializer';
import { UrlSerializer } from '@angular/router';
import { SizeConverterComponent } from './size-converter/size-converter.component';
import { NewCartComponent } from './new-cart/new-cart.component';
import { CookieService } from 'ngx-cookie-service';
import { ProdComponent } from './prod/prod.component';
import { CacheInterceptor } from './cache.interceptor';
import { CookieHowToComponent } from './cookie-how-to/cookie-how-to.component';
import { CookieConsentComponent } from './cookie-consent/cookie-consent.component';
import { MyHistoryComponent } from './my-history/my-history.component';
import { RepComponent } from './rep/rep.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { HowToExchangeComponent } from './how-to-exchange/how-to-exchange.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { CuratedForCustomerComponent } from './curated-for-customer/curated-for-customer.component';
import { NumberToWordsPipe } from './services/num2text.pipe';
import { CartRecommendComponent } from './cart-recommend/cart-recommend.component';
import { VerifyComponent } from './verify/verify.component';
import { ProdDetail1Component } from './prod-detail1/prod-detail1.component';
import { ProdListComponent1 } from './prod-list1/prod-list1.component';
import { HowToCheckSizeComponent } from './how-to-check-size/how-to-check-size.component';







@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProdListComponent,
    ProdDetailComponent,
    OrderCartComponent,
    RelatedProductsComponent,
    OtherColorsComponent,
    MenuLinksComponent,
    RecentlyViewedComponent,
    FooterComponent,
    AboutComponent,
    ExchangeComponent,
    ContactComponent,
    FaqComponent,
    HowItWorksComponent,
    DeliveryInfoComponent,
    PrivacyComponent,
    TermsComponent,
    VacanciesComponent,
    PaymentOptionsComponent,
    PageNotFoundComponent,
    CatalogComponent,
    SizeConverterComponent,
    NewCartComponent,
    ProdComponent,
    CookieConsentComponent,
    CookieHowToComponent,
    ReviewsComponent,
    RepComponent,
    MyHistoryComponent,
    HowToExchangeComponent,
    OrderHistoryComponent,
    CuratedForCustomerComponent,
    NumberToWordsPipe,
    CartRecommendComponent,
    VerifyComponent,
    ProdDetail1Component,
    ProdListComponent1,
    HowToCheckSizeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    AppRoutingModule,
    FlexLayoutModule,
    NgImageSliderModule,
    NgDynamicBreadcrumbModule,
    ReactiveFormsModule
  ],
  providers:[ {
    provide: HTTP_INTERCEPTORS,
    useClass: ApiCallsInterceptor,
    multi: true,
  }, GoogleAnalyticsService, FacebookEventService, CartGuard,CookieService,
    {
      provide: UrlSerializer,
      useClass: LowerCaseUrlSerializer
    },
    { provide: HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
