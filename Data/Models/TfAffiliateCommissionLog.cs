using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Affiliate_CommissionLog")]
    public partial class TfAffiliateCommissionLog
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        [StringLength(50)]
        public string AffiliateId { get; set; }
        public int? AdId { get; set; }
        public int? AffiliateReferralId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column(TypeName = "money")]
        public decimal? Commission { get; set; }
        public int? AdTypeId { get; set; }
        [Column(TypeName = "money")]
        public decimal? ReceiptTotal { get; set; }
        public int? ReceiptId { get; set; }
    }
}
