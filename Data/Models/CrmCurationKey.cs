using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("CRM_CurationKey")]
    public partial class CrmCurationKey
    {
        [Key]
        [Column("curationID")]
        [StringLength(16)]
        public string curationID { get; set; }
        [Column("trackingId")]
        [StringLength(8)]
        public string trackingId { get; set; }
        [StringLength(13)]
        public string customerGSM { get; set; }
        [StringLength(30)]
        public string customerName { get; set; }
        public int lftDeptId { get; set; }
        public int rgtDeptId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime dateAdded { get; set; }
        public int byUserID { get; set; }
        public int numOfViews { get; set; }
    }
}
