import { Injectable } from '@angular/core';

declare let fbq: Function; // Declare gtag as a function

@Injectable()
export class FacebookEventService {

  constructor() { }

  public eventEmitter(
    eventAction: string,
    eventLabel: string = null,
    eventValue: number = null) {

    fbq('track', eventAction, { value: (Math.round(eventValue * 100) / 100).toFixed(2), currency: 'NGN', orderId: eventLabel });
  }

  public viewContent(eventValue: number = null, productId: number = null, departmentName: string, title: string) {
    fbq('track', 'ViewContent', {
      content_ids: [productId], content_type: 'product', value: (Math.round(eventValue * 100) / 100).toFixed(2), content_name: title, content_category: departmentName, currency: 'NGN'
    });
  }

  public addToCart(eventValue: number = null, productId: number = null, departmentName: string, title: string) {
    fbq('track', 'AddToCart', {
      content_ids: [productId], content_type: 'product', value: (Math.round(eventValue * 100) / 100).toFixed(2), content_name: title, content_category: departmentName, currency: 'NGN'
    });
  }

  public initiateCheckout(eventValue: number = null, orderId: number = null) {
    fbq('track', 'InitiateCheckout', { value: (Math.round(eventValue * 100) / 100).toFixed(2), currency: 'NGN', orderId: orderId });
  }

  public initiatePurchase(eventValue: number = null, orderId: number = null) {
    fbq('track', 'Purchase', { value: (Math.round(eventValue * 100) / 100).toFixed(2), currency: 'NGN', orderId: orderId });
  }

  public initiateLeadGen(eventValue: number = null, orderId: number = null) {
    fbq('trackCustom', 'LeadGen', { value: (Math.round(eventValue * 100) / 100).toFixed(2), currency: 'NGN', orderId: orderId });
  }
}
