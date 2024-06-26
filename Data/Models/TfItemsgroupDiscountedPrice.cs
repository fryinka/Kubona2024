using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Itemsgroup_DiscountedPrices")]
    public partial class TfItemsgroupDiscountedPrice
    {
        [Key]
        public int ItemGroupDiscountId { get; set; }
        public int? ItemGroupId { get; set; }
        [Column(TypeName = "money")]
        public decimal? DiscountedPrice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column("byUserId")]
        public int? ByUserId { get; set; }
    }
}
