using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("BAG_EventShop")]
    public partial class BagEventShop
    {
        [Key]
        [Column("eventShopId")]
        public int EventShopId { get; set; }
        [Column("eventId")]
        public int EventId { get; set; }
        [Required]
        [StringLength(150)]
        public string ContactEmail { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        [StringLength(35)]
        public string ContactName { get; set; }
        [Column("verificationCode")]
        [StringLength(7)]
        public string VerificationCode { get; set; }
        public int? City { get; set; }
        public int? Age { get; set; }
        public int? Sex { get; set; }
        public int? TimeOfDay { get; set; }
        public int? DayOfWeek { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
    }
}
