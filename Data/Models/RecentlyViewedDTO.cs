using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class RecentlyViewedDTO
    {

        public RecentlyViewedDTO() { }

        public int itemId { get; set; }
         public string title { get; set; }
        public string imageUrl { get; set; }

        public decimal? internetPrice { get; set; }
        public string urlId { get; set; }
        public DateTime viewDate { get; set; }

        

    }
}
