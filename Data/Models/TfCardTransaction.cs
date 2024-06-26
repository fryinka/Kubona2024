using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Card_Transactions")]
    public partial class TfCardTransaction
    {
        [Key]
        [StringLength(50)]
        public string TransactionId { get; set; }
        public int OrderId { get; set; }
        [Column("gateWayId")]
        public int GateWayId { get; set; }
        [StringLength(10)]
        public string ResponseCode { get; set; }
        [StringLength(250)]
        public string ResponseDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }
        [Column("IPAddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
        [Column("tranxmsg")]
        public string Tranxmsg { get; set; }
    }
}
