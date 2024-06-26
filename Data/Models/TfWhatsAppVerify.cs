using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_WhatsApp_Verify")]
    public partial class TfWhatsAppVerify
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("Status")]
        [StringLength(50)]
        public string Status { get; set; }
        [Column("DateSent", TypeName = "datetime")]
        public DateTime? DateSent { get; set; }
    }
}
