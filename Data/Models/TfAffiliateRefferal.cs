using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_AffiliateRefferal")]
    public partial class TfAffiliateRefferal
    {
        [Key]
        public int AffiliateRefferalId { get; set; }
        [Required]
        [StringLength(50)]
        public string AnonymousId { get; set; }
        [Required]
        [StringLength(16)]
        public string AffiliateId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateVisited { get; set; }
        public int? AddId { get; set; }
    }
}
