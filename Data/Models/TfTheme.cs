using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Themes")]
    public partial class TfTheme
    {
        [Key]
        public int ThemeId { get; set; }
        [StringLength(50)]
        public string ThemeName { get; set; }
        [StringLength(500)]
        public string ThemeDesc { get; set; }
        public int? ThemeGroupId { get; set; }
    }
}
