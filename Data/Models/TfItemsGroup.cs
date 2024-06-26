using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ItemsGroup")]
    [Index(nameof(ItemGroupId), nameof(PositionId), Name = "NCI_ItemgroupId_PositionId", IsUnique = true)]
    [Index(nameof(DepartmentId), nameof(Isactive), nameof(NumAvailable), Name = "Tf_itemsgroup_BySearch")]
    [Index(nameof(Isactive), nameof(NumAvailable), Name = "pk_itemsgroup_param")]
    [Index(nameof(Isactive), nameof(NumAvailable), Name = "tf_items_group_isactive")]
    [Index(nameof(Isactive), nameof(ColorId), nameof(NumAvailable), Name = "tf_itemsgroup_getactive")]
    public partial class TfItemsGroup
    {
        public TfItemsGroup()
        {
            TfItemsgroupSizes = new HashSet<TfItemsgroupSize>();
        }

        [Key]
        public int ItemGroupId { get; set; }
        public int? DepartmentId { get; set; }
        [StringLength(75)]
        public string Title { get; set; }
        [Column("searchTags")]
        [StringLength(200)]
        public string SearchTags { get; set; }
        public string Description { get; set; }
        public int? NumOfViews { get; set; }
        [StringLength(150)]
        public string SquareImageUrl { get; set; }
        [StringLength(150)]
        public string HighResolutionUrl { get; set; }
        public int? CollectionId { get; set; }
        [Column("vendorprice", TypeName = "money")]
        public decimal? Vendorprice { get; set; }
        [Column("storeprice", TypeName = "money")]
        public decimal? Storeprice { get; set; }
        [Column("limitprice", TypeName = "money")]
        public decimal? Limitprice { get; set; }
        [Column("internetprice", TypeName = "money")]
        public decimal? Internetprice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("rating")]
        public int? Rating { get; set; }
        [Column("location")]
        [StringLength(20)]
        public string Location { get; set; }
        [Column("producttype")]
        public int? Producttype { get; set; }
        [Column("startPrice", TypeName = "money")]
        public decimal? StartPrice { get; set; }
        [Column("isfeatured")]
        public bool? Isfeatured { get; set; }
        [Column("posref")]
        [StringLength(16)]
        public string Posref { get; set; }
        [Column("isactive")]
        public bool? Isactive { get; set; }
        [StringLength(2)]
        public string QualityCrit { get; set; }
        [StringLength(20)]
        public string YouTubeId { get; set; }
        [Column("isHot")]
        public bool? IsHot { get; set; }
        [Column("brandId")]
        public int? BrandId { get; set; }
        [Column("offerPrice", TypeName = "money")]
        public decimal? OfferPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? BazaarPrice { get; set; }
        [StringLength(150)]
        public string MobileImageUrl { get; set; }
        [Column("colorId")]
        public int? ColorId { get; set; }
        [Column("similarId")]
        [StringLength(16)]
        public string SimilarId { get; set; }
        [Column("numAvailable")]
        public int? NumAvailable { get; set; }
        [Column("trackingId")]
        [StringLength(10)]
        public string TrackingId { get; set; }
        [Column("details")]
        public string Details { get; set; }
        [Column("materialId")]
        public int? MaterialId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        public int? PositionId { get; set; }
        [Column("frontPagePositionId")]
        public int? FrontPagePositionId { get; set; }
        [Column("heelHeight")]
        public int? HeelHeight { get; set; }
        [Column("StyleId")]
        public int? StyleId { get;set; }

        public virtual TfDepartment TfDepartment { get; set; }

        public virtual BwColor BwColor { get; set; }

        public virtual BwBrand BwBrand { get; set; }
        public virtual TfHeelHeight TfHeelHeight { get; set; }
        public virtual TfSubDepartment TfSubDepartment { get; set; }
        //public virtual TfSimilar TfSimilar { get; set; }

        //public virtual BwMaterial BwMaterial { get; set; }

        [InverseProperty(nameof(TfItemsgroupSize.ItemGroup))]
        public virtual ICollection<TfItemsgroupSize> TfItemsgroupSizes { get; set; }

        public virtual ICollection<TfItemsImage> TfItemsgroupImages { get; set; }


    }
}
