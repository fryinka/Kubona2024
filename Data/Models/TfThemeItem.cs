using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Theme_Items")]
    public partial class TfThemeItem
    {
        [Key]
        public int ThemeId { get; set; }
        [Key]
        public int ItemGroupId { get; set; }
        [Column("position")]
        public int? Position { get; set; }
    }
}
