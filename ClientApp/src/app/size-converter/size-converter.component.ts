import { Component, Inject, OnInit } from "@angular/core";
import { sizeChart, USSize } from "../models/prod-list";
import { SEOService } from "../services/seo.service";

@Component({
  selector: "app-size-converter",
  templateUrl: "./size-converter.component.html",
  styleUrls: ["./size-converter.component.css"],
})
export class SizeConverterComponent implements OnInit {
  public result: string;
  public message: string;
  public foundSize: sizeChart;
  public url: string;
  public size: number;
  public genderId: number;
  public gender: string;
  public standard: string;
  public shoeFit: string;
  public newStandard: string = "Euro";
  public highlight: string = "yellow";

  public sizeCat: any[] = [];
  public USMen: USSize[] = [
    { value: 6 },
    { value: 6.5 },
    { value: 7 },
    { value: 7.5 },
    { value: 8 },
    { value: 8.5 },
    { value: 9 },
    { value: 9.5 },
    { value: 10 },
    { value: 10.5 },
    { value: 11 },
    { value: 11.5 },
    { value: 12 },
    { value: 13 },
    { value: 14 },
    { value: 15 },
    { value: 16 },
  ];
  public USWomen: USSize[] = [
    { value: 4 },
    { value: 4.5 },
    { value: 5 },
    { value: 5.5 },
    { value: 6 },
    { value: 6.5 },
    { value: 7 },
    { value: 7.5 },
    { value: 8 },
    { value: 8.5 },
    { value: 9 },
    { value: 9.5 },
    { value: 10 },
    { value: 10.5 },
    { value: 11 },
    { value: 11.5 },
    { value: 12 },
  ];
  public UKMen: USSize[] = [
    { value: 5.5 },
    { value: 6 },
    { value: 6.5 },
    { value: 7 },
    { value: 7.5 },
    { value: 8 },
    { value: 8.5 },
    { value: 9 },
    { value: 9.5 },
    { value: 10 },
    { value: 10.5 },
    { value: 11 },
    { value: 11.5 },
    { value: 12.5 },
    { value: 13.5 },
    { value: 14.5 },
    { value: 15.5 },
  ];
  public UKWomen: USSize[] = [{ value: 2 }, { value: 2.5 }, { value: 3 }, { value: 3.5 }, { value: 4 }, { value: 4.5 }, { value: 5 },
  { value: 5.5 },
  { value: 6 },
  { value: 6.5 },
  { value: 7 },
  { value: 7.5 },
  { value: 8 },
  { value: 8.5 },
  { value: 9 },
  { value: 9.5 },
  { value: 10 },
  ];
  public EuroMen: any[] = [
    { value: "39" },
    { value: "39" },
    { value: "40" },
    { value: "40-41" },
    { value: "41" },
    { value: "41-42" },
    { value: "42" },
    { value: "42-43" },
    { value: "43" },
    { value: "43-44" },
    { value: "44" },
    { value: "44-45" },
    { value: "45" },
    { value: "46" },
    { value: "47" },
    { value: "48" },
    { value: "49" }

  ]
  public EuroWomen: any[] = [
    { value: "35" },
    { value: "35" },
    { value: "35-36" },
    { value: "36" },
    { value: "36-37" },
    { value: "37" },
    { value: "37-38" },
    { value: "38" },
    { value: "38-39" },
    { value: "39" },
    { value: "39" },
    { value: "40" },
    { value: "40-41" },
    { value: "41" },
    { value: "41-42" },
    { value: "42" },
    { value: "42-43" }
  ]

  public sizeChart: sizeChart[] = [
    { usSize: 6, ukSize: 5.5, euroSize: "39", genderId: 70610 },
    { usSize: 6.5, ukSize: 6, euroSize: "39", genderId: 70610 },
    { usSize: 7, ukSize: 6.5, euroSize: "40", genderId: 70610 },
    { usSize: 7.5, ukSize: 7, euroSize: "40-41", genderId: 70610 },
    { usSize: 8, ukSize: 7.5, euroSize: "41", genderId: 70610 },
    { usSize: 8.5, ukSize: 8, euroSize: "41-42", genderId: 70610 },
    { usSize: 9, ukSize: 8.5, euroSize: "42", genderId: 70610 },
    { usSize: 9.5, ukSize: 9, euroSize: "42-43", genderId: 70610 },
    { usSize: 10, ukSize: 9.5, euroSize: "43", genderId: 70610 },
    { usSize: 10.5, ukSize: 10, euroSize: "43-44", genderId: 70610 },
    { usSize: 11, ukSize: 10.5, euroSize: "44", genderId: 70610 },
    { usSize: 11.5, ukSize: 11, euroSize: "44-45", genderId: 70610 },
    { usSize: 12, ukSize: 11.5, euroSize: "45", genderId: 70610 },
    { usSize: 13, ukSize: 12.5, euroSize: "46", genderId: 70610 },
    { usSize: 14, ukSize: 13.5, euroSize: "47", genderId: 70610 },
    { usSize: 15, ukSize: 14.5, euroSize: "48", genderId: 70610 },
    { usSize: 16, ukSize: 15.5, euroSize: "49", genderId: 70610 },
    { usSize: 4, ukSize: 2, euroSize: "35", genderId: 70710 },
    { usSize: 4.5, ukSize: 2.5, euroSize: "35", genderId: 70710 },
    { usSize: 5, ukSize: 3, euroSize: "35-36", genderId: 70710 },
    { usSize: 5.5, ukSize: 3.5, euroSize: "36", genderId: 70710 },
    { usSize: 6, ukSize: 4, euroSize: "36-37", genderId: 70710 },
    { usSize: 6.5, ukSize: 4.5, euroSize: "37", genderId: 70710 },
    { usSize: 7, ukSize: 5, euroSize: "37-38", genderId: 70710 },
    { usSize: 7.5, ukSize: 5.5, euroSize: "38", genderId: 70710 },
    { usSize: 8, ukSize: 6, euroSize: "38-39", genderId: 70710 },
    { usSize: 8.5, ukSize: 6.5, euroSize: "39", genderId: 70710 },
    { usSize: 9, ukSize: 7, euroSize: "39-40", genderId: 70710 },
    { usSize: 9.5, ukSize: 7.5, euroSize: "40", genderId: 70710 },
    { usSize: 10, ukSize: 8, euroSize: "40-41", genderId: 70710 },
    { usSize: 10.5, ukSize: 8.5, euroSize: "41", genderId: 70710 },
    { usSize: 11, ukSize: 9, euroSize: "41-42", genderId: 70710 },
    { usSize: 11.5, ukSize: 9.5, euroSize: "42", genderId: 70710 },
    { usSize: 12, ukSize: 10, euroSize: "42-43", genderId: 70710 },
    { usSize: 12.5, ukSize: 10.5, euroSize: "43", genderId: 70710 }
  ]
  public msizeChart:sizeChart[]=[
    { usSize: 6, ukSize: 5.5, euroSize: "39", genderId: 70610 },
    { usSize: 6.5, ukSize: 6, euroSize: "39", genderId: 70610 },
    { usSize: 7, ukSize: 6.5, euroSize: "40", genderId: 70610 },
    { usSize: 7.5, ukSize: 7, euroSize: "40-41", genderId: 70610 },
    { usSize: 8, ukSize: 7.5, euroSize: "41", genderId: 70610 },
    { usSize: 8.5, ukSize: 8, euroSize: "41-42", genderId: 70610 },
    { usSize: 9, ukSize: 8.5, euroSize: "42", genderId: 70610 },
    { usSize: 9.5, ukSize: 9, euroSize: "42-43", genderId: 70610 },
    { usSize: 10, ukSize: 9.5, euroSize: "43", genderId: 70610 },
    { usSize: 10.5, ukSize: 10, euroSize: "43-44", genderId: 70610 },
    { usSize: 11, ukSize: 10.5, euroSize: "44", genderId: 70610 },
    { usSize: 11.5, ukSize: 11, euroSize: "44-45", genderId: 70610 },
    { usSize: 12, ukSize: 11.5, euroSize: "45", genderId: 70610 },
    { usSize: 13, ukSize: 12.5, euroSize: "46", genderId: 70610 },
    { usSize: 14, ukSize: 13.5, euroSize: "47", genderId: 70610 },
    { usSize: 15, ukSize: 14.5, euroSize: "48", genderId: 70610 },
    { usSize: 16, ukSize: 15.5, euroSize: "49", genderId: 70610 }
  ]
  public wsizeChart:sizeChart[]=[
    { usSize: 4, ukSize: 2, euroSize: "35", genderId: 70710 },
    { usSize: 4.5, ukSize: 2.5, euroSize: "35", genderId: 70710 },
    { usSize: 5, ukSize: 3, euroSize: "35-36", genderId: 70710 },
    { usSize: 5.5, ukSize: 3.5, euroSize: "36", genderId: 70710 },
    { usSize: 6, ukSize: 4, euroSize: "36-37", genderId: 70710 },
    { usSize: 6.5, ukSize: 4.5, euroSize: "37", genderId: 70710 },
    { usSize: 7, ukSize: 5, euroSize: "37-38", genderId: 70710 },
    { usSize: 7.5, ukSize: 5.5, euroSize: "38", genderId: 70710 },
    { usSize: 8, ukSize: 6, euroSize: "38-39", genderId: 70710 },
    { usSize: 8.5, ukSize: 6.5, euroSize: "39", genderId: 70710 },
    { usSize: 9, ukSize: 7, euroSize: "39-40", genderId: 70710 },
    { usSize: 9.5, ukSize: 7.5, euroSize: "40", genderId: 70710 },
    { usSize: 10, ukSize: 8, euroSize: "40-41", genderId: 70710 },
    { usSize: 10.5, ukSize: 8.5, euroSize: "41", genderId: 70710 },
    { usSize: 11, ukSize: 9, euroSize: "41-42", genderId: 70710 },
    { usSize: 11.5, ukSize: 9.5, euroSize: "42", genderId: 70710 },
    { usSize: 12, ukSize: 10, euroSize: "42-43", genderId: 70710 },
    { usSize: 12.5, ukSize: 10.5, euroSize: "43", genderId: 70710 }
  ]
  constructor(private seoService: SEOService) { }

  ngOnInit(): void {
    // this.seoService.updateDescription('Shoe Size Converter');
    // this.seoService.updateTitle('Shoe Size Converter - Kubona - Premium Italian Leather Shoes.');
  }

  selectStandard(event: any) {
    this.standard = event.target.value;
    this.getUSSizes();
    if (this.genderId != null && this.standard != null && this.shoeFit != null) {
      this.convertSize();
    }
  }
  selectGender(event: any) {
    this.genderId = Number(event.target.value);
    if (this.genderId === 70610) {
      this.gender = "Men";
    }
    if (this.genderId === 70710) {
      this.gender = "Women";
    }
    this.getUSSizes();

    if (this.genderId != null && this.standard != null && this.size != null && this.shoeFit != null) {
      this.convertSize();
    }
  }
  selectSize(event: any) {
    this.size = Number(event.target.value);
    this.convertSize();
  }
  selectFit(event: any) {
    this.shoeFit = event.target.value;
    if (this.genderId != null && this.standard != null && this.size != null && this.shoeFit != null) {
      this.convertSize();
    }
  }

  getUSSizes() {
    if (this.genderId === 70610 && this.standard === "US") {
      this.sizeCat = this.USMen;
      if (this.size != null) {
        this.size = this.sizeCat[0].value;
      }
    } else if (this.genderId === 70710 && this.standard === "US") {
      this.sizeCat = this.USWomen;
      if (this.size != null) {
        this.size = this.sizeCat[0].value;
      }
    } else if (this.genderId === 70610 && this.standard === "UK") {
      this.sizeCat = this.UKMen;
      if (this.size != null) {
        this.size = this.sizeCat[0].value;
      }
    } else if (this.genderId === 70710 && this.standard === "UK") {
      this.sizeCat = this.UKWomen;
      if (this.size != null) {
        this.size = this.sizeCat[0].value;
      }
    }
  }

  convertSize() {
    if (this.standard === "US") {
      // console.log(this.size);
      for (var i = 0; i < this.sizeChart.length; i++) {
        if (this.sizeChart[i].usSize === Number(this.size) && this.sizeChart[i].genderId === Number(this.genderId)) {
          // console.log("From Service: ", i)
          this.foundSize = this.sizeChart[i];
          let tempRest: string[] = this.foundSize.euroSize.split("-");
          if(tempRest.length <=1 && this.shoeFit === "wide"){
            this.result = tempRest[0];  
            this.message = "Your Size in Euro is: " + this.result;
            // console.log("con",this.result,tempRest);          
            this.url = this.genderId + "-" + "100" + tempRest[1] + "-0-0-sz-" + tempRest[1] + "-" + this.gender + "-shoes";
          }
          if (tempRest.length > 1 && this.shoeFit === "wide") {
            this.result = tempRest[1];  
            this.message = "Your Size in Euro is: " + this.result;
            // console.log("con",this.result,tempRest);          
            this.url = this.genderId + "-" + "100" + tempRest[1] + "-0-0-sz-" + tempRest[1] + "-" + this.gender + "-shoes";
          }
          else if (this.shoeFit==="narrow"){
            this.result = tempRest[0];            
            this.message = "Your Size in Euro is: " + this.result;
            // console.log("narr",this.result, tempRest);          
            this.url = this.genderId + "-" + "100" + tempRest[0] + "-0-0-sz-" + tempRest[0] + "-" + this.gender + "-shoes";
          } 
          return this.sizeChart[i];
        }
      }
    }
    if (this.standard === "UK") {
      // console.log(this.size);
      for (var i = 0; i < this.sizeChart.length; i++) {
        if (this.sizeChart[i].ukSize === Number(this.size) && this.sizeChart[i].genderId === Number(this.genderId)) {
          // console.log("From Service: ", i)
          this.foundSize = this.sizeChart[i];
          let tempRest: string[] = this.foundSize.euroSize.split("-");
          if(tempRest.length <=1 && this.shoeFit === "wide"){
            this.result = tempRest[0];  
            this.message = "Your Size in Euro is: " + this.result;
            // console.log("con",this.result,tempRest);          
            this.url = this.genderId + "-" + "100" + tempRest[1] + "-0-0-sz-" + tempRest[1] + "-" + this.gender + "-shoes";
          }
          if (tempRest.length > 1 && this.shoeFit === "wide") {
            this.result = tempRest[1];  
            this.message = "Your Size in Euro is: " + this.result;
            // console.log("con",this.result,tempRest);          
            this.url = this.genderId + "-" + "100" + tempRest[1] + "-0-0-sz-" + tempRest[1] + "-" + this.gender + "-shoes";
          }
          else if (this.shoeFit==="narrow"){
            this.result = tempRest[0];            
            this.message = "Your Size in Euro is: " + this.result;
            // console.log("narr",this.result,tempRest);          
            this.url = this.genderId + "-" + "100" + tempRest[0] + "-0-0-sz-" + tempRest[0] + "-" + this.gender + "-shoes";
          } 
          return this.sizeChart[i];
        }
      }
    }

  }

}
