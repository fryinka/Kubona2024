using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Itemsgroup_Sizes")]
    public partial class TfItemsgroupSize
    {
        [Key]
        public int ItemGroupSizeId { get; set; }
        public int ItemGroupId { get; set; }
        [Required]
        [StringLength(10)]
        public string TrackingId { get; set; }
        public int? Quantity { get; set; }
        public int? SizeCode { get; set; }

        [ForeignKey(nameof(ItemGroupId))]
        [InverseProperty(nameof(TfItemsGroup.TfItemsgroupSizes))]
        public virtual TfItemsGroup ItemGroup { get; set; }
    }
}
