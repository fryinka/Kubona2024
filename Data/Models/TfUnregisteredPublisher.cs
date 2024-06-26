using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_UnregisteredPublisher")]
    public partial class TfUnregisteredPublisher
    {
        [Key]
        public int PubId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int? Category { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        [Column("isFeatured")]
        public bool? IsFeatured { get; set; }
        [Column("imageUrl")]
        [StringLength(150)]
        public string ImageUrl { get; set; }
        [Column("profile")]
        [StringLength(500)]
        public string Profile { get; set; }
    }
}
