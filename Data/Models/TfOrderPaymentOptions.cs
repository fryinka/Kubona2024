using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Order_PaymentOptions")]
    public partial class TfOrderPaymentOptions
    {
        [Key]
        [Column("OrderId")]
        public int OrderId { get; set; }
        [Column("PaymentOption")]
        public int PaymentOption { get; set; }
    }
}
