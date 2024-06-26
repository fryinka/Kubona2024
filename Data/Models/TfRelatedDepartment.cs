using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_RelatedDepartments")]
    public partial class TfRelatedDepartment
    {
        [Key]
        public int DepartmentId { get; set; }
        [Key]
        [Column("relatedDepartmentId")]
        public int RelatedDepartmentId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int? Strength { get; set; }
    }
}
