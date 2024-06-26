using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_DiscountCode_DeActivateLog")]
    public partial class TfDiscountCodeDeActivateLog
    {
        [Key]
        [StringLength(8)]
        public string DiscountCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }
        [Required]
        [Column("IPAddress")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
    }
}
