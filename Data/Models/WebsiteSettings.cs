using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class WebsiteSettings
    {
        public string Customergsm { get; set; }
        public string Servicegsm { get; set; }
        public string Servicegsm2 { get; set; }
        public string Servicegsm3 { get; set; }
        public int ServiceSwitch { get; set; }
        public string YouTubeVideoHeight { get; set; }
        public string YouTubeVideoWidth  { get; set; }
        public string WhatsappVerifyApiUrl { get; set; }
        public string WhatsappVerifyApiToken { get; set; }
        public string UrlShortenerUrl { get; set; }
        public string UrlShortenerKey { get;set; }
        public string UrlShortenerHost { get; set; }
        
    }
}
