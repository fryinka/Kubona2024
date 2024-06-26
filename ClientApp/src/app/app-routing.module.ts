import { InjectionToken, NgModule } from '@angular/core';
import { Routes, RouterModule, ActivatedRouteSnapshot } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AddressComponent } from './address/address.component';
import { ContactComponent } from './contact/contact.component';
import { DeliveryInfoComponent } from './delivery-info/delivery-info.component';
import { ExchangeComponent } from './exchange/exchange.component';
import { FaqComponent } from './faq/faq.component';
import { HomeComponent } from './home/home.component';
import { HowItWorksComponent } from './how-it-works/how-it-works.component';
// import { NewlyArrivedComponent } from './newly-arrived/newly-arrived.component';
import { OrderCartComponent } from './order-cart/order-cart.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PaymentOptionsComponent } from './payment-options/payment-options.component';
import { PrivacyComponent } from './privacy/privacy.component';
import { ProdDetailComponent } from './prod-detail/prod-detail.component';
import { ProdListComponent } from './prod-list/prod-list.component'
import { TermsComponent } from './terms/terms.component';
import { VacanciesComponent } from './vacancies/vacancies.component';
import { CatalogComponent } from './catalog/catalog.component';
import { CartGuard } from './cart.guard';
import { RedirectComponent } from './redirect/redirect.component';
import { SizeConverterComponent } from './size-converter/size-converter.component';
import { NewCartComponent } from './new-cart/new-cart.component';
import { CookieHowToComponent } from './cookie-how-to/cookie-how-to.component';
import { MyHistoryComponent } from './my-history/my-history.component';
import { HowToExchangeComponent } from './how-to-exchange/how-to-exchange.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { CuratedForCustomerComponent } from './curated-for-customer/curated-for-customer.component';
import { CartRecommendComponent } from './cart-recommend/cart-recommend.component';
import { VerifyComponent } from './verify/verify.component';
import { ProdDetail1Component } from './prod-detail1/prod-detail1.component';
import { ProdListComponent1 } from './prod-list1/prod-list1.component';
import { HowToCheckSizeComponent } from './how-to-check-size/how-to-check-size.component';
//import { SearchPageComponent } from './search-page/search-page.component';


const externalUrlProvider = new InjectionToken('externalUrlRedirectResolver');

const routes: Routes = [
  { path: '', component: HomeComponent, data: {title: 'Home', breadcrumb: [{label: 'Kubona',url: ''}] }, pathMatch: 'full'},
  {
    path: 'category/:departmentId', component: ProdListComponent, data: {
      title: 'Category',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: '{{categoryName}}',
          url: 'category/:departmentId'
        },
      ]
    }
  },
  {
    path: 'category/:departmentId/:sortId', component: ProdListComponent, data: {
      title: 'Category',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: '{{categoryName}}',
          url: 'category/:departmentId'
        },
      ]
    }
  },
  {
    path: 'category1/:departmentId', component: ProdListComponent1, data: {
      title: 'Category',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: '{{categoryName}}',
          url: 'category/:departmentId'
        },
      ]
    }
  },
  {
    path: 'category1/:departmentId/:sortId', component: ProdListComponent1, data: {
      title: 'Category',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: '{{categoryName}}',
          url: 'category/:departmentId'
        },
      ]
    }
  },
  //{ path: 'category', component:SearchPageComponent },
  {
    path: 'product/:productId', component: ProdDetailComponent, data: {
      title: 'Category',
      breadcrumb: [
        {
          label: 'Kubona',
          url: ''
        },
        {
          label: '{{categoryName}}',
          url: 'category/:departmentId'
        },
        {
          label: '{{productName}}',
          url:''
        },
      ]
    }
},
//   {
//     path: 'product1/:productId', component: ProdDetail1Component, data: {
//       title: 'Category',
//       breadcrumb: [
//         {
//           label: 'Kubona',
//           url: ''
//         },
//         {
//           label: '{{categoryName}}',
//           url: 'category/:departmentId'
//         },
//         {
//           label: '{{productName}}',
//           url:''
//         },
//       ]
//     }
// },
  {
    path: 'whatsapp', component: OrderCartComponent, data: {
      title: 'Shoppping Cart',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Shopping Cart',
          url: ''
        },
      ]
    }
},
  //{ path: 'whatsapp1', component: NewCartComponent, data:{
  //  title:'Shopping Cart',
  //  breadcrumb:[
  //    {
  //    label: 'Kubona',
  //    url:'/'
  //  },
  //  {
  //    label:'Shopping Cart',
  //    url:''
  //  }
  //]
  //}},
  {
    path: 'verify', component: VerifyComponent, data: {
      title: 'Shoppping Cart',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Shopping Cart',
          url: ''
        },
      ]
    }
},
  // { path: 'newlyarrived', component: NewlyArrivedComponent },
  { path: 'catalog', component: CatalogComponent, data: {
    title: 'Shoppping Cart',
    breadcrumb: [
      {
        label: 'Kubona',
        url: '/'
      },
      {
        label: 'Catalog',
        url: ''
      },
    ]
  }},
  {
    path: 'about', component: AboutComponent, data: {
      title: 'About us',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'About us',
          url: ''
        },
      ]
    }
},
  {
    path: 'exchange', component: ExchangeComponent, data: {
      title: 'Exchange or Return Policy',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Help',
          url: 'faq'
        },
        {
          label: 'Exchange or Return Policy',
          url: ''
        },
      ]
    }
},
  {
    path: 'contact', component: ContactComponent, data: {
      title: 'Contact us',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Contact us',
          url: ''
        },
      ]
    }
},
  {
    path: 'faq', component: FaqComponent, data: {
      title: 'Help',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Help',
          url: ''
        },
      ]
    }
},  
  {
    path: 'howitworks', component: HowItWorksComponent, data: {
      title: 'How Kubona.ng works',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'How Kubona.ng works',
          url: ''
        },
      ]
    }
},  
  {
    path: 'delivery', component: DeliveryInfoComponent, data: {
      title: 'Shop With Confidence!',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Shop With Confidence!',
          url: ''
        },
      ]
    }
},
  {
    path: 'privacy', component: PrivacyComponent, data: {
      title: 'Privacy',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Privacy',
          url: ''
        },
      ]
    }
},  
  {
    path: 'terms', component: TermsComponent, data: {
      title: 'Terms of Condition',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Terms of Condition',
          url: ''
        },
      ]
    }
},  
  {
    path: 'vacancies', component: VacanciesComponent, data: {
      title: 'Corporate Careers',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Corporate Careers',
          url: ''
        },
      ]
    }
},  
  {
    path: 'address', component: AddressComponent, data: {
      title: 'Directions to Kubona',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Help',
          url: 'faq'
        },
        {
          label: 'Directions to Kubona',
          url: ''
        },
      ]
    }
},  
  {
    path: 'paymentoptions', component: PaymentOptionsComponent, data: {
      title: 'Payment Options',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Payment Options',
          url: ''
        },
      ]
    }
},
  {
    path: 'sizeconverter', component: SizeConverterComponent, data: {
      title: 'Shoe Size Converter',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Shoe Size Converter',
          url: ''
        },
      ]
    }
},
  {
    path: 'sizehowto', component: HowToCheckSizeComponent, data: {
      title: 'How to check Shoe size',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'How to check Shoe size',
          url: ''
        },
      ]
    }
},
  {
    path: 'cookiehowto', component: CookieHowToComponent, data: {
      title: 'How to enable Cookies',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'How to enable Cookies',
          url: ''
        },
      ]
    }
},
  {
    path: 'history', component: MyHistoryComponent, data: {
      title: 'My Browsing History',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'My Browsing History',
          url: ''
        },
      ]
    }
},
  {
    path: 'curation/:curationId', component: CuratedForCustomerComponent, data: {
      title: 'Personal Recommendations',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Personal Recommendations',
          url: ''
        },
      ]
    }
},
{
  path: 'cartrecommend', component: CartRecommendComponent, data: {
    title: 'Shop more Items',
    breadcrumb: [
      {
        label: 'Kubona',
        url: '/'
      },
      {
        label: 'Shop more items',
        url: ''
      },
    ]
  }
},
  {
    path: 'exchangeprocess', component: HowToExchangeComponent, data: {
      title: 'Exchange Process',
      breadcrumb: [
        {
          label: 'Kubona',
          url: '/'
        },
        {
          label: 'Help',
          url: 'faq'
        },
        {
          label: 'Exchange or Return Policy',
          url:'exchange'
        },
        {
          label: 'Exchange Process',
          url: ''
        },
      ]
    }
  },
  //{
  //  path: 'orderhistory', component: OrderHistoryComponent, data: {
  //    title: 'Order History',
  //    breadcrumb: [
  //      {
  //        label: 'Kubona',
  //        url:'/'
  //      },
  //      {
  //        label: 'My Order History',
  //        url:''
  //      }
  //    ]
  //  }
  //},
  { path: 'externalRedirect', resolve: { url: externalUrlProvider,}, component: RedirectComponent},
  { path: '**', component:PageNotFoundComponent}
];
@NgModule({
  providers: [
    {
      provide: externalUrlProvider,
      useValue: (route: ActivatedRouteSnapshot) => {
        const externalUrl = route.paramMap.get('externalUrl');
        window.open(externalUrl, '_self');
      },
    },
  ],
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled', onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }


