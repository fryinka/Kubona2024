using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_SaleEvent_Items")]
    public partial class TfSaleEventItem
    {
        [Key]
        public int SaleEventId { get; set; }
        [Key]
        public int ItemGroupId { get; set; }
        [Column("position")]
        public int? Position { get; set; }
        [Column(TypeName = "money")]
        public decimal? OfferPrice { get; set; }
    }
}
