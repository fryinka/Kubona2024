using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class TfDepartmentGroupByDTO
    {

        public TfDepartmentGroupByDTO() { }

        public int departmentId { get; set; }
        public string description { get; set; }
        public int totalCount { get; set; }
        public string destinationUrl { get; set; }
    }
}
