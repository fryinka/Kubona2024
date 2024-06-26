using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class RelatedProductsDTO
    {
        public RelatedProductsDTO() { }
        public int? itemgroupId { get; set; }

        public string title { get; set; }
        public decimal? internetPrice { get; set; }
        public string imageUrl { get; set; }
        public string urlId { get; set; }
       
       
    }
}
