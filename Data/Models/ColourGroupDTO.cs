using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class ColourGroupDTO
    {
        public ColourGroupDTO() { }

        public int? colorId { get; set; }
        public string colorDesc { get; set; }
        public int totalcount { get; set; }
       
        public string destinationUrl { get; set; }
    }
}
