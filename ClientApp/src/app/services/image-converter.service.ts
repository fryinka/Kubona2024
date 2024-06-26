import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ImageConverterService {

  constructor() { }
  
  jpgToWebp(imageUrl:string){
    if (imageUrl.toLowerCase().endsWith('.jpg') || imageUrl.toLowerCase().endsWith('.jpeg') || imageUrl.toLowerCase().endsWith('.png')) {
      return imageUrl.replace(/\.(jpg|jpeg|png)$/i, '.webp');
  } else {
      return imageUrl;
  }
  }
}
