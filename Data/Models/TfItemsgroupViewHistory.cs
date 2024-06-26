using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
   
    [Table("TF_ItemsGroup_ViewHistory")]
    public partial class TfItemsgroupViewHistory
    {
        [Key]
        public int ViewId { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ViewDate { get; set; }
        public int NumOfViews { get; set; }
    }
}
