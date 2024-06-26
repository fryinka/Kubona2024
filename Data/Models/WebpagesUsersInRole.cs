using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("webpages_UsersInRoles")]
    public partial class WebpagesUsersInRole
    {
        [Key]
        public int RoleUserId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
    }
}
