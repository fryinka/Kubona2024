using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Keyless]
    [Table("_BigCommerceMigration")]
    public partial class BigCommerceMigration
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
        [StringLength(12)]
        public string SizeDesc { get; set; }
        [Column("internetprice", TypeName = "money")]
        public decimal? Internetprice { get; set; }
        [Column("storeprice", TypeName = "money")]
        public decimal? Storeprice { get; set; }
        [Column("vTrackingid")]
        [StringLength(8)]
        public string VTrackingid { get; set; }
        [Column("vQuantity")]
        public int? VQuantity { get; set; }
        [Column("image1Src")]
        [StringLength(150)]
        public string Image1Src { get; set; }
        [Column("image2Src")]
        [StringLength(150)]
        public string Image2Src { get; set; }
        [Column("image3Src")]
        [StringLength(150)]
        public string Image3Src { get; set; }
        [Column("image4Src")]
        [StringLength(150)]
        public string Image4Src { get; set; }
        [Column("image5Src")]
        [StringLength(150)]
        public string Image5Src { get; set; }
        [Column("image6Src")]
        [StringLength(150)]
        public string Image6Src { get; set; }
        [Column("image7Src")]
        [StringLength(150)]
        public string Image7Src { get; set; }
        [Column("image8Src")]
        [StringLength(150)]
        public string Image8Src { get; set; }
        [Column("counter")]
        public int? Counter { get; set; }
        [Column("materialId")]
        public int? MaterialId { get; set; }
        [Column("materialTag")]
        [StringLength(35)]
        public string MaterialTag { get; set; }
    }
}
