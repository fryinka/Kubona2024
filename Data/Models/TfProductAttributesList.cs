using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ProductAttributes_List")]
    public partial class TfProductAttributesList
    {
        [Key]
        public int AttributeId { get; set; }
        public int? CategoryId { get; set; }
        [StringLength(35)]
        public string AttrDesc { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int? ByUserId { get; set; }
    }
}
