using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ParameterTypes")]
    public partial class TfParameterType
    {
        [Key]
        public int ParamTypeId { get; set; }
        [StringLength(20)]
        public string ParamTypeName { get; set; }
        [Column("departmentId")]
        public int? DepartmentId { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("IPaddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
        public int? PositionId { get; set; }
    }
}
