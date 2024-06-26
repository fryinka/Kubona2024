using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_MenuLinks")]
    public partial class TfMenuLink
    {
        [Key]
        public int LinkId { get; set; }
        [StringLength(25)]
        public string ShortTitle { get; set; }
        [Required]
        [Column("destinationUrl")]
        [StringLength(150)]
        public string DestinationUrl { get; set; }
        [Column("categoryId")]
        public int? CategoryId { get; set; }
        [Column("departmentId")]
        public int? DepartmentId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
    }
}
