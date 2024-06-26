using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Keyless]
    [Table("TF_Items_ViewHistory2")]
    public partial class TfItemsViewHistory2
    {
        [StringLength(50)]
        public string UserId { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ViewDate { get; set; }
        public int NumOfViews { get; set; }
    }
}
