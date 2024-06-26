using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_CheckinCheckout_Log")]
    public partial class TfCheckinCheckoutLog
    {
        [Key]
        public int CheckId { get; set; }
        [Required]
        [StringLength(10)]
        public string TrackingId { get; set; }
        public int? RefId { get; set; }
        public int QtyModify { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }
        [StringLength(50)]
        public string Notes { get; set; }
    }
}
