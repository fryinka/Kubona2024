using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_AffiliateLink")]
    public partial class TfAffiliateLink
    {
        [Key]
        [Column("adId")]
        public int AdId { get; set; }
        [Required]
        [Column("destinationUrl")]
        [StringLength(100)]
        public string DestinationUrl { get; set; }
        [Required]
        [Column("affiliateId")]
        [StringLength(16)]
        public string AffiliateId { get; set; }
        [Required]
        [Column("adName")]
        [StringLength(50)]
        public string AdName { get; set; }
        [Required]
        [Column("generatedCode")]
        [StringLength(50)]
        public string GeneratedCode { get; set; }
        public int? TypeId { get; set; }
    }
}
