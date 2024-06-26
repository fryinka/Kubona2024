using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("UserProfile")]
    public partial class UserProfile
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Column("userName")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Column("sex")]
        public int? Sex { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        public int? Location { get; set; }
        [Column("GSM")]
        [StringLength(13)]
        public string Gsm { get; set; }
    }
}
