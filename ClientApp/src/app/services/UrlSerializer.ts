import { DefaultUrlSerializer, UrlTree } from '@angular/router';

export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
  parse(url: string): UrlTree {

    var urlstring: string[];
    var urlmain: string = null;
    if (url) {

      urlstring = url.split('?');
      if (urlstring.length > 1) {
        urlmain = urlstring[0].toLowerCase();
        return super.parse(urlmain.concat('?', urlstring[1]));
      } else {
        urlmain = urlstring[0].toLowerCase();
        return super.parse(urlmain);
      }
      
    }

    return super.parse(url.toLowerCase());
  }
}
