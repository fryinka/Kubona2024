using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("POS_Discount_UsageLog")]
    public partial class PosDiscountUsageLog
    {
        [Key]
        public int DiscountAppliedId { get; set; }
        [Column("amountUsed", TypeName = "money")]
        public decimal AmountUsed { get; set; }
        [Column("dateUsed", TypeName = "datetime")]
        public DateTime DateUsed { get; set; }
        [Column("refId")]
        public int RefId { get; set; }
        [Required]
        [Column("customerGSM")]
        [StringLength(13)]
        public string CustomerGsm { get; set; }
        [Column("isCancelled")]
        public bool? IsCancelled { get; set; }
    }
}
