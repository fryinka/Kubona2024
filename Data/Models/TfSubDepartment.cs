using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Kubona.Data.Models
{
    [Table("TF_SubDepartment")]
    public partial class TfSubDepartment
    {
        [Key]
        public int SubDepartmentId { get; set; }
        public int DepartmentId { get; set; }   
        public string SubDepartment { get; set; }

        public virtual ICollection<TfItemsGroup> TfItemsGroups { get; set; }
    }
}
