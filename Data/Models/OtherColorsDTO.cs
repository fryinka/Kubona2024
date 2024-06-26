using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class OtherColorsDTO
    {

        public OtherColorsDTO() { }

        public string title { set; get; }
        public string mobileImageUrl { set; get; }
        public string urlId { set; get; }
        public int productId { get; set; }

        public decimal? internetPrice { set; get; }
    }
}
