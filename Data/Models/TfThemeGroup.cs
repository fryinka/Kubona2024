using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ThemeGroups")]
    public partial class TfThemeGroup
    {
        [Key]
        public int ThemeGroupId { get; set; }
        [StringLength(25)]
        public string ThemeGroupName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
    }
}
