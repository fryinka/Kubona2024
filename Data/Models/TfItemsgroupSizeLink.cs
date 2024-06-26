using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Itemsgroup_SizeLink")]
    public partial class TfItemsgroupSizeLink
    {
        [Required]
        [StringLength(8)]
        public string SimilarId { get; set; }
        [Required]
        [StringLength(16)]
        public string SizeDesc { get; set; }
        [Key]
        public int ItemgroupId { get; set; }
    }
}
