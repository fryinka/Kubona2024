using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Affiliates_Reference")]
    public partial class TfAffiliatesReference
    {
        [Key]
        [Column("referenceId")]
        public int ReferenceId { get; set; }
        [Column("sendToNumber")]
        [StringLength(13)]
        public string SendToNumber { get; set; }
        [Column("IPAddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
        [Column("isSent")]
        public bool? IsSent { get; set; }
    }
}
