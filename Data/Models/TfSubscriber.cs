using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Keyless]
    [Table("TF_Subscribers")]
    public partial class TfSubscriber
    {
        public int SubscriberId { get; set; }
        [Column("subscriber")]
        [StringLength(150)]
        public string Subscriber { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [Column("GSM")]
        [StringLength(15)]
        public string Gsm { get; set; }
        public int? Country { get; set; }
        [Column("DOB", TypeName = "datetime")]
        public DateTime? Dob { get; set; }
        public int? Sex { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("IPAddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
        [Column("emailVerified")]
        [StringLength(10)]
        public string EmailVerified { get; set; }
        [Column("emailCode")]
        [StringLength(20)]
        public string EmailCode { get; set; }
        [Column("hasPaidSubscription")]
        public bool? HasPaidSubscription { get; set; }
        public int? PhoneDeviceId { get; set; }
        [StringLength(150)]
        public string ImageUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastPasswordRequestDate { get; set; }
        public int? Location { get; set; }
        public int? Area { get; set; }
        public int? Profession { get; set; }
        public int? Education { get; set; }
        [Column("creditBalance", TypeName = "money")]
        public decimal? CreditBalance { get; set; }
    }
}
