using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("webpages_Roles")]
    public partial class WebpagesRole
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [StringLength(256)]
        public string RoleName { get; set; }
    }
}
