using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_SaleEvents")]
    public partial class TfSaleEvent
    {
        [Key]
        public int SaleEventId { get; set; }
        [StringLength(50)]
        public string SaleEventName { get; set; }
        [StringLength(500)]
        public string SaleEventDesc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
