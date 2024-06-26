using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Order_Report")]
    public partial class TfOrderReport
    {
        [Key]
        public int OrderId { get; set; }
        [StringLength(500)]
        public string ReportDetails { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column("byUserId")]
        public int? ByUserId { get; set; }
    }
}
