using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Newsletter_Subscribers")]
    public partial class TfNewsletterSubscriber
    {
        [Key]
        [Column("subscriberId")]
        public int SubscriberId { get; set; }
        [Column("email")]
        [StringLength(150)]
        public string Email { get; set; }
        [Column("firstName")]
        [StringLength(35)]
        public string FirstName { get; set; }
        public int? NewsletterType { get; set; }
        [Column("isActive")]
        public int? IsActive { get; set; }
        [Column("validationCode")]
        [StringLength(8)]
        public string ValidationCode { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("ipaddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
    }
}
