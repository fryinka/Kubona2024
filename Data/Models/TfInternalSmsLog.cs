using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Keyless]
    [Table("TF_InternalSMS_Log")]
    public partial class TfInternalSmsLog
    {
        [Column("GSM")]
        [StringLength(15)]
        public string Gsm { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(160)]
        public string Message { get; set; }
        public int? MsgType { get; set; }
    }
}
