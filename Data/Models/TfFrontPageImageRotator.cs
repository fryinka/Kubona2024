using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_FrontPage_ImageRotator")]
    public partial class TfFrontPageImageRotator
    {
        [Key]
        public int ImageId { get; set; }
        [StringLength(150)]
        public string ImageUrl { get; set; }
        [Column("imageTitle")]
        [StringLength(30)]
        public string ImageTitle { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column("DestinationURL")]
        [StringLength(150)]
        public string DestinationUrl { get; set; }
        public int? Position { get; set; }
        [StringLength(75)]
        public string Summary { get; set; }
        public int? RotatorId { get; set; }
        [Column("thumbNailUrl")]
        [StringLength(150)]
        public string ThumbNailUrl { get; set; }
    }
}
