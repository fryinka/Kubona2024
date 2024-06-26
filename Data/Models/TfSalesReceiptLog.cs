using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_SalesReceipt_Log")]
    public partial class TfSalesReceiptLog
    {
        [Key]
        [Column("receiptId")]
        public int ReceiptId { get; set; }
        public int? ContactId { get; set; }
        [Column(TypeName = "money")]
        public decimal? ReceiptTotal { get; set; }
        [Column("deliveryCharges", TypeName = "money")]
        public decimal? DeliveryCharges { get; set; }
        [Column("handlingCharges", TypeName = "money")]
        public decimal? HandlingCharges { get; set; }
        [Column("discount", TypeName = "money")]
        public decimal? Discount { get; set; }
        [Column("discountCode")]
        [StringLength(8)]
        public string DiscountCode { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int? ReceiptStatus { get; set; }
    }
}
