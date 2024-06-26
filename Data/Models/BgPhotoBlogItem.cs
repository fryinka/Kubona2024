using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("BG_PhotoBlog_Items")]
    public partial class BgPhotoBlogItem
    {
        [Key]
        public int ImageId { get; set; }
        public int? PhotoBlogId { get; set; }
        [Column("imageurl")]
        [StringLength(150)]
        public string Imageurl { get; set; }
        [StringLength(200)]
        public string Imagetitle { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int? Position { get; set; }

        [ForeignKey(nameof(PhotoBlogId))]
        [InverseProperty(nameof(BgPhotoBlog.BgPhotoBlogItems))]
        public virtual BgPhotoBlog PhotoBlog { get; set; }
    }
}
