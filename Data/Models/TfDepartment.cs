using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Department")]
    public partial class TfDepartment
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int Depth { get; set; }
        public int Lft { get; set; }
        public int Rgt { get; set; }
        public int? SortOrder { get; set; }
        [Column("imageurl")]
        [StringLength(300)]
        public string Imageurl { get; set; }
        [Column("position")]
        public int? Position { get; set; }
        public int? Level1Parent { get; set; }
        public int? ParentId { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isfeatured")]
        public bool? Isfeatured { get; set; }
        [Column("GOOGLEID")]
        public int? Googleid { get; set; }
        [Column("CODCode")]
        public int? Codcode { get; set; }
        public int? WhatsAppCode { get; set; }
        
        public virtual ICollection<TfItemsGroup> TfItemsGroups { get; set; }
    }
}
