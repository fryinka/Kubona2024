import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { Cartlist } from "../models/order.model";
import { OrderService } from "./order.service";

@Injectable({
  providedIn: "root",
})
export class SpinnerService {
  private loading = new BehaviorSubject<boolean>(false);
  public readonly loading$ = this.loading.asObservable();
  hideMatBadge: boolean;
  private badgeCounter = new BehaviorSubject<number>(0);
  public badgeCounter$ = this.badgeCounter.asObservable();
  public count: number = 0;

  constructor() {}

  show() {
    this.loading.next(true);
  }
  hide() {
    setTimeout(() => {
      this.loading.next(false);
    }, 5000);
  }

  increaseCounter() {
    this.count = this.count + 1;
    this.badgeCounter.next(this.count);
  }
  decreaseCounter() {
    this.count = this.count - 1;
    this.badgeCounter.next(this.count);
  }
  resetCounter() {
    this.count = 0;
    this.badgeCounter.next(this.count);
   }
}
