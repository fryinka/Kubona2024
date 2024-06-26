using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Itemsgroup_DescriptionUpdated_Log")]
    public partial class TfItemsgroupDescriptionUpdatedLog
    {
        [Key]
        public int ItemgroupId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int ByUserId { get; set; }
    }
}
