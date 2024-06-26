using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_RelatedProducts")]
    public partial class TfRelatedProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Key]
        public int RelatedProductId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int? Strength { get; set; }
    }
}
