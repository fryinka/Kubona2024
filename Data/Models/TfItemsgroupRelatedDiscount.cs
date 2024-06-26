using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Itemsgroup_RelatedDiscounts")]
    public partial class TfItemsgroupRelatedDiscount
    {
        [Key]
        public int ItemGroupRelatedDiscountId { get; set; }
        public int MainItemGroupId { get; set; }
        public int RelatedItemGroupId { get; set; }
        public int? PositionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }
        public int ByUserId { get; set; }
    }
}
