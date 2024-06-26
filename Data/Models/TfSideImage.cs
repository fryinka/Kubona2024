using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_SideImages")]
    public partial class TfSideImage
    {
        [Key]
        public int ImageId { get; set; }
        public int? PageId { get; set; }
        [Column("imageUrl")]
        [StringLength(150)]
        public string ImageUrl { get; set; }
        public int? PositionId { get; set; }
        [StringLength(250)]
        public string DestinationUrl { get; set; }
        [StringLength(50)]
        public string ImageTitle { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int? UserId { get; set; }
    }
}
