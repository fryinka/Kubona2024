using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ItemsImages")]
    public partial class TfItemsImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        [StringLength(150)]
        public string SquareImageUrl { get; set; }
        [StringLength(150)]
        public string RecImageUrl { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("addedByIP")]
        [StringLength(20)]
        public string AddedByIp { get; set; }
        [Column("mobileProductImageUrl")]
        [StringLength(150)]
        public string MobileProductImageUrl { get; set; }
        [Column("desktopProductImageUrl")]
        [StringLength(150)]
        public string DesktopProductImageUrl { get; set; }

        [ForeignKey(nameof(ProductId))]
       
        public virtual TfItemsGroup ItemGroup { get; set; }

    }
}
