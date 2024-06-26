using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class SizingGroupDTO
    {
        public SizingGroupDTO() { }

        public int? sizeCode { get; set; }
        public string sizeDesc { get; set; }
        public int totalcount { get; set; }
        public int? departmentId { get; set; }
        public string destinationUrl { get; set; }

    }
}
