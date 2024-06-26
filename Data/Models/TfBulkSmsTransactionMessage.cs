using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_BulkSMS_TransactionMessages")]
    public partial class TfBulkSmsTransactionMessage
    {
        [Key]
        public int MsgId { get; set; }
        [Key]
        [Column("transactionId")]
        [StringLength(50)]
        public string TransactionId { get; set; }
        [Column("isProcessed")]
        public bool? IsProcessed { get; set; }
    }
}
