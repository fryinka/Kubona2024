using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class MenuLinksDTO
    {

        public MenuLinksDTO() { }

        public int LinkId { get; set; }
        public string RouteId { get; set; }
        public string RouteUrl { get; set; }
        public string ShortTitle { get; set; }



    }
}
