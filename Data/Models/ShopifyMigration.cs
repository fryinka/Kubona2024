using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Keyless]
    [Table("_ShopifyMigration")]
    public partial class ShopifyMigration
    {
        [StringLength(8)]
        public string TrackingId { get; set; }
        [StringLength(75)]
        public string Title { get; set; }
        public string Body { get; set; }
        [StringLength(35)]
        public string StyleTag { get; set; }
        [StringLength(35)]
        public string ColorTag { get; set; }
        public int? ImagePosition { get; set; }
        [StringLength(150)]
        public string ImageSrc { get; set; }
        public int? Quantity { get; set; }
        [StringLength(10)]
        public string SizeDesc { get; set; }
        [Column("internetprice", TypeName = "money")]
        public decimal? Internetprice { get; set; }
        [Column("storeprice", TypeName = "money")]
        public decimal? Storeprice { get; set; }
    }
}
