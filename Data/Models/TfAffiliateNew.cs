using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_AffiliateNew")]
    public partial class TfAffiliateNew
    {
        [Key]
        [StringLength(50)]
        public string AffiliateId { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("GSM")]
        [StringLength(13)]
        public string Gsm { get; set; }
        public int? TotalDiscount { get; set; }
        [StringLength(50)]
        public string UserId { get; set; }
        [Column("isSync")]
        public bool? IsSync { get; set; }
        [Column("verificationcode")]
        [StringLength(4)]
        public string Verificationcode { get; set; }
        [Column("isVerified")]
        public bool? IsVerified { get; set; }
    }
}
