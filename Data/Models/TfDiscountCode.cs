using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Discount_Codes")]
    public partial class TfDiscountCode
    {
        [Key]
        public int DiscountId { get; set; }
        [StringLength(80)]
        public string DiscountCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        [Column("forUserGSM")]
        [StringLength(11)]
        public string ForUserGsm { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isSynced")]
        public bool? IsSynced { get; set; }
        [Column("codeValue", TypeName = "money")]
        public decimal? CodeValue { get; set; }
        [Column("percentOff", TypeName = "money")]
        public decimal? PercentOff { get; set; }
        [Column("numUsed")]
        public int? NumUsed { get; set; }
        [Column("isSent")]
        public bool? IsSent { get; set; }
    }
}
