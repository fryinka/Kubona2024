using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_BulkSMSLog")]
    public partial class TfBulkSmslog
    {
        public int? UserId { get; set; }
        [Key]
        [StringLength(50)]
        public string TransactionId { get; set; }
        [StringLength(400)]
        public string Message { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("sentStatus")]
        public int? SentStatus { get; set; }
        [Column("totalCount")]
        public int? TotalCount { get; set; }
        [Column("msgType")]
        public int? MsgType { get; set; }
    }
}
