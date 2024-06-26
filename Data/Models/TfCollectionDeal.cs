using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Collection_Deals")]
    public partial class TfCollectionDeal
    {
        [Key]
        public int SaleId { get; set; }
        [Column("collectionId")]
        public int CollectionId { get; set; }
        public int Quantity { get; set; }
        [StringLength(75)]
        public string DiscountTitle { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("IPAddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
        [Column("addedById")]
        public int? AddedById { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column(TypeName = "money")]
        public decimal? PriceGreaterThan { get; set; }
        [Column("freeQuantity")]
        public int? FreeQuantity { get; set; }
        [Column(TypeName = "money")]
        public decimal? PriceLessThan { get; set; }
        [Column("freecollectionId")]
        public int? FreecollectionId { get; set; }
        [Column(TypeName = "money")]
        public decimal? PercentageOff { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        public int Duration { get; set; }
        public int? DiscountTypeId { get; set; }
        [Column("longDiscountTitle")]
        public string LongDiscountTitle { get; set; }
        [Column("limitQty")]
        public int? LimitQty { get; set; }
        [Column("isfeatured")]
        public bool? Isfeatured { get; set; }
        [Column("freeCollectionId2")]
        public int? FreeCollectionId2 { get; set; }
        [Column("imageUrl")]
        [StringLength(150)]
        public string ImageUrl { get; set; }
        [StringLength(150)]
        public string MainImageUrl { get; set; }
        public int? SyncCode { get; set; }
        [Column("batchId")]
        [StringLength(4)]
        public string BatchId { get; set; }
    }
}
