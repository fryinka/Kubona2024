using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    public partial class BigCommerceCheckDatum
    {
        public string Category { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(25)]
        public string Manufacturer { get; set; }
        [Key]
        [Column("ShopSKU")]
        public int ShopSku { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? SalePrice { get; set; }
        [StringLength(150)]
        public string ImageUrl { get; set; }
        [Column("googleid")]
        public int? Googleid { get; set; }
        [Column("trackingid")]
        [StringLength(8)]
        public string Trackingid { get; set; }
        [StringLength(150)]
        public string ProductUrl { get; set; }
    }
}
