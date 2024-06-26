using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class FrontPageDTO
    {
        public FrontPageDTO() { }
        public string Imageurl { get; set; }
        public string ImageTitle { get; set; }
        public string Summary { get; set; }
        public string RouteUrl { get; set; }
        public string RouteId { get; set; }



    }
}
