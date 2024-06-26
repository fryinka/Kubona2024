import { Component, OnInit } from '@angular/core';
import { DomSanitizer,SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-how-to-exchange',
  templateUrl: './how-to-exchange.component.html',
  styleUrls: ['./how-to-exchange.component.css']
})
export class HowToExchangeComponent implements OnInit {
  youTubeId: SafeResourceUrl;
  url='https://www.youtube.com/embed/73nvrzhPYHQ';
  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.youTubeId=this.sanitizer.bypassSecurityTrustResourceUrl(this.url);
  }

}
