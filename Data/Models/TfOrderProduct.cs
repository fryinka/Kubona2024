using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Order_Product")]
    public partial class TfOrderProduct
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }
        public int AddedByUserId { get; set; }
        [Column(TypeName = "money")]
        public decimal? ShippingCharges { get; set; }
        [Column(TypeName = "money")]
        public decimal? HandlingCharges { get; set; }
        public int NumOfItems { get; set; }
        public int? ShippingMode { get; set; }
        public int? ShipToId { get; set; }
        [Required]
        [Column("IPAddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
        public int? NumOfDeliveries { get; set; }
        [Column(TypeName = "money")]
        public decimal? OrderAmount { get; set; }
        [Column("discount", TypeName = "money")]
        public decimal? Discount { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        public int? SyncStatus { get; set; }
        [Column("discountCode")]
        [StringLength(8)]
        public string DiscountCode { get; set; }
        [Column("expirydate", TypeName = "datetime")]
        public DateTime? Expirydate { get; set; }
        [Column("statusCode")]
        public int? StatusCode { get; set; }
        [Column("sourceId")]
        public int? SourceId { get; set; }
        [Column("lastUserId")]
        public int? LastUserId { get; set; }
        [Column("affiliateId")]
        [StringLength(25)]
        public string AffiliateId { get; set; }
        [Column("affiliateReferralId")]
        public int? AffiliateReferralId { get; set; }
        [Column("gclid")]
        public string Gclid { get; set; }
        [Column("fbclid")]
        public string Fbclid { get; set; }
    }
}
