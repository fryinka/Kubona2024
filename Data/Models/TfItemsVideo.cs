using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ItemsVideos")]
    public partial class TfItemsVideo
    {
        [Key]
        [StringLength(25)]
        public string VideoId { get; set; }
        public int? ProductId { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("addedByIP")]
        [StringLength(20)]
        public string AddedByIp { get; set; }
    }
}
