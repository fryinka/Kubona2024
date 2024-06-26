using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("BG_PhotoBlog")]
    public partial class BgPhotoBlog
    {
        public BgPhotoBlog()
        {
            BgPhotoBlogItems = new HashSet<BgPhotoBlogItem>();
        }

        [Key]
        public int PhotoBlogId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("summary")]
        [StringLength(500)]
        public string Summary { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("addedBy")]
        public int? AddedBy { get; set; }
        [Column("coverImageUrl")]
        [StringLength(150)]
        public string CoverImageUrl { get; set; }

        [InverseProperty(nameof(BgPhotoBlogItem.PhotoBlog))]
        public virtual ICollection<BgPhotoBlogItem> BgPhotoBlogItems { get; set; }
    }
}
