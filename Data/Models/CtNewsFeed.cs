using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("CT_NewsFeed")]
    public partial class CtNewsFeed
    {
        [Key]
        public int NewsId { get; set; }
        [StringLength(75)]
        public string Title { get; set; }
        [Required]
        [StringLength(250)]
        public string Details { get; set; }
        [Column("ReferenceURL")]
        [StringLength(150)]
        public string ReferenceUrl { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int? ByUserId { get; set; }
        public int? StatusCode { get; set; }
        [Column("isFeatured")]
        public int? IsFeatured { get; set; }
        [Column("imageUrl")]
        [StringLength(150)]
        public string ImageUrl { get; set; }
        [StringLength(150)]
        public string MobileImageUrl { get; set; }
        [Column("categoryId")]
        public int? CategoryId { get; set; }
        [Column("appId")]
        public int? AppId { get; set; }
    }
}
