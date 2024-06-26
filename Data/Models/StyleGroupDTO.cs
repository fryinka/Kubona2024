using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class StyleGroupDTO
    {
        public StyleGroupDTO() { }

        public int? styleId { get; set; }
        public string styleDesc { get; set; }
        public int totalcount { get; set; }
        public int? departmentId { get; set; }
        public string destinationUrl { get; set; }
    }
}
