using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("BW_Brands")]
    public partial class BwBrand
    {
        [Key]
        public int BrandId { get; set; }
        [StringLength(35)]
        public string BrandName { get; set; }
        [Column("isfeatured")]
        public bool? Isfeatured { get; set; }
        [Column("brandAlphabetCode")]
        public int? BrandAlphabetCode { get; set; }
        [Column("coverImageUrl")]
        [StringLength(150)]
        public string CoverImageUrl { get; set; }

        public virtual ICollection<TfItemsGroup> TfItemsGroups { get; set; }
    }
}
