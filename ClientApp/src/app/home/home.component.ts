import { Component, OnInit } from '@angular/core';
import { FrontPageImageRotator } from '../models/frontPageImageRotator';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { FrontPageService } from '../services/frontpage.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public frontpageImages: FrontPageImageRotator[];
  public cols: number = 3;
  public pageSize: number = 12;
  public rotatorId: number = 2;

  constructor(private breakpointObserver: BreakpointObserver,
    private frontPageService: FrontPageService, private googleService: GoogleAnalyticsService) {
  }

  ngOnInit() {

    this.breakpointObserver.observe([
      Breakpoints.Handset,
      Breakpoints.Tablet,
      Breakpoints.Web
    ]).subscribe(result => {
      if (result.matches) {
        if (result.breakpoints['(max-width: 599.98px) and (orientation: portrait)'] || result.breakpoints['(max-width: 599.98px) and (orientation: landscape)']) {
          this.cols = 1;
        }
        else if (result.breakpoints['(min-width: 1280px) and (orientation: portrait)'] || result.breakpoints['(min-width: 1280px) and (orientation: landscape)']) {
          this.cols = 3;
        } else {
          this.cols = 2;
        }
      }
    });

    // this.frontPageService.getFrontPageItems<FrontPageImageRotator>(this.rotatorId,this.pageSize)
    //   .subscribe(result => { this.frontpageImages = result; }, error => console.error(error)); 
    this.frontPageService.getFrontPageItems<FrontPageImageRotator>(this.rotatorId, this.pageSize)
      .subscribe(
        result => {
          this.frontpageImages = result.map(item => {
            item.imageurl = `../../assets/${this.getImageFileName(item.imageTitle)}`;
            return item;
          });
        },
        error => console.error(error)
      );
  }

  getImageFileName(imageTitle: string): string {
    // Example logic: Replace spaces with underscores and convert to lowercase
    return imageTitle.replace(/\s+/g, '_').toLowerCase() + '.webp';
  }

  sendBottomLinkEvent(eventLabel: string) {
    //this.googleService.eventEmitter("front_page", "lower_links", eventLabel, 0);
    this.googleService.homepageEventEmitter("front_page", "lower_links", eventLabel);
  }

  sendWidgetClickEvent(eventLabel: string) {
    //this.googleService.eventEmitter("front_page", "widget_click", eventLabel, 0);
    this.googleService.homepageEventEmitter("front_page", "widget_click", eventLabel);
  }

}
