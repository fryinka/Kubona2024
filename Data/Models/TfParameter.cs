using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Parameters")]
    public partial class TfParameter
    {
        [Key]
        public int ParamId { get; set; }
        [StringLength(25)]
        public string ParamName { get; set; }
        [Column("paramTypeId")]
        public int? ParamTypeId { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("IPAddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
        [Column("departmentId")]
        public int? DepartmentId { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
    }
}
