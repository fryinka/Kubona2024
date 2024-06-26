using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Subscribers_Preset")]
    public partial class TfSubscribersPreset
    {
        [Key]
        [Column("GSM")]
        [StringLength(13)]
        public string Gsm { get; set; }
        public int Country { get; set; }
        public int Location { get; set; }
        [Column("area")]
        public int Area { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        [Required]
        [Column("IPAddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
        [Required]
        [Column("onlineCode")]
        [StringLength(4)]
        public string OnlineCode { get; set; }
        [Required]
        [Column("mobileCode")]
        [StringLength(4)]
        public string MobileCode { get; set; }
        [Column("numSent")]
        public int? NumSent { get; set; }
        [Column("isVerified")]
        public bool? IsVerified { get; set; }
    }
}
