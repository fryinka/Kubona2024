using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class NgImageSliderDTO
    {

        public NgImageSliderDTO() { }
        public string image { set; get; }
        public string thumbImage { set; get; }
        public string alt { set; get; }
        public string title { set; get; }
        public int order { set; get; }

    }
}
