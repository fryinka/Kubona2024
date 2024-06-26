import { Injectable } from '@angular/core';

declare let gtag:Function; // Declare gtag as a function

@Injectable()
export class GoogleAnalyticsService {

  constructor() { }


  //create our event emitter to send our data to Google Analytics
  public eventEmitter(eventAction: string, eventCategory: string, eventLabel: string = null, eventValue: number = null)
  {
    gtag('event', eventAction, { 'event_category': eventCategory, 'event_label': eventLabel, 'value': eventValue });
      //gtag('event', 'ga4_' + eventAction, { 'event_label': eventLabel, 'value': eventValue });   
  }
  //GA4 event emitter ---
  public ga4eventEmitter(eventAction: string, order_id: string = null, eventValue: number = null) {
    gtag('event', eventAction, { 'order_id': order_id, 'value': eventValue });
  }

  public addToCartEventEmitter(eventAction: string, page_name:string, productId: string, productValue) {
    gtag('event', eventAction, { 'product_id': productId, 'page_name':page_name, 'value': productValue });
  }
  public prodReviewEventEmitter(eventAction: string, page_name: string, product_name: string) {
    gtag('event', eventAction, { 'product_name': product_name, 'page_name':page_name});
  }

  public recentlyViewedEventEmitter(eventAction: string,productTitle:string, page_name: string, product_value:string) {
    gtag('event', eventAction, { 'product_title':productTitle,'page_name': page_name, 'value': product_value });
  }

  public homepageEventEmitter(eventAction: string, link_location: string, link_clicked: string) {
    gtag('event', eventAction, { 'link_location': link_location, 'link_clicked': link_clicked });
  }
  // this method is for the general
  public ga4GenEventEmitter(eventAction: string,page_name:string) {
    gtag('event', eventAction, { 'page_name': page_name });
  }

  public prodlistEventEmitter(eventAction: string, page_name: string, product_url: string) {
    gtag('event', eventAction, { 'page_name': page_name, 'product_url': product_url });
  }

  public searchListEventEmitter(eventAction: string, page_name: string, filter_btn: string) {
    gtag('event', eventAction, { 'page_name': page_name, 'filter': filter_btn });
  }
  public checkoutRadioEventEmitter(eventAction: string, order_id: string, pytOption: string) {
    gtag('event', eventAction, { 'order_id': order_id, 'checkoutOption': pytOption });
  }

  public viewContent(eventValue: number = null, productId: number, departmentName: string) {
    gtag('event', 'view_item', {
      'send_to': 'AW-1062104035',
      'value': eventValue,
      'items': [{
        'id': productId,
        'google_business_vertical': 'retail'
      }],
      'ecomm_pagetype': departmentName
    });
    //gtag('event', 'view_content', { 'event_category': 'product_detail', 'event_label': productId, 'value': eventValue });
    gtag('event', 'view_content', { 'page_name': 'product_detail', 'productId': productId, 'value': eventValue });
  }

  public reportConversion(url: string, eventValue: number = null) {
    //var callback = function () {
    //  if (typeof (url) != 'undefined') {
    //    //window.location = url;
    //  }
    //};
    //gtag('event', 'conversion', {
    //  'send_to': 'AW Id',
    //  'event_callback': callback
    //});

  //  var callback = function (url) {
  //    if (typeof (url) != 'undefined') {
  //      window.location = url;
  //    };
  //};


    gtag('event', 'conversion', {
      'send_to': 'AW-ID', 'value': eventValue, 'currency': 'NGN', 'callback':url
    });
  }
}
