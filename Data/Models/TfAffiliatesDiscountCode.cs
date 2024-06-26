using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Affiliates_Discount_Codes")]
    public partial class TfAffiliatesDiscountCode
    {
        [Key]
        public int AffiliateReferralId { get; set; }
        [Required]
        [StringLength(16)]
        public string AffiliateId { get; set; }
        [Required]
        [StringLength(80)]
        public string DiscountCode { get; set; }
        [Column("email")]
        [StringLength(150)]
        public string Email { get; set; }
        [Column("fname")]
        [StringLength(35)]
        public string Fname { get; set; }
        [Column("gsm")]
        [StringLength(15)]
        public string Gsm { get; set; }
    }
}
