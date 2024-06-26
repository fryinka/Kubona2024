using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Order_VisaUrl")]
    public partial class TfOrderVisaUrl
    {
        [Key]
        [Column("orderId")]
        public int OrderId { get; set; }
        [Key]
        [Column("transactionId")]
        [StringLength(50)]
        public string TransactionId { get; set; }
        [Column("tellerId")]
        [StringLength(15)]
        public string TellerId { get; set; }
        [Column("tellerNumber")]
        [StringLength(50)]
        public string TellerNumber { get; set; }
        [Column("url")]
        [StringLength(250)]
        public string Url { get; set; }
        [Column("xml")]
        public string Xml { get; set; }
    }
}
