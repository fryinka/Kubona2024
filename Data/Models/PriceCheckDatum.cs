using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    public partial class PriceCheckDatum
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
        [Column("themeDesc")]
        [StringLength(1000)]
        public string ThemeDesc { get; set; }
        public int? ThemeId { get; set; }
        [StringLength(50)]
        public string ThemeName { get; set; }
        [Column("sizeDesc")]
        [StringLength(250)]
        public string SizeDesc { get; set; }
        [Column("colorId")]
        public int? ColorId { get; set; }
        [Column("additionalimages")]
        public string Additionalimages { get; set; }

        public int? ProductType { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int? AvailableSizeCount { get; set; }

        public int? DepartmentId { get; set; }

    }

}
