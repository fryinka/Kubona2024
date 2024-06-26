using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Affiliates")]
    public partial class TfAffiliate
    {
        [Key]
        public int AffiliateId { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("GSM")]
        [StringLength(13)]
        public string Gsm { get; set; }
        public int? OrderId { get; set; }
        public int? TypeId { get; set; }
        [StringLength(8)]
        public string ReferralId { get; set; }
    }
}
