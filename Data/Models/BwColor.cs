using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("BW_Colors")]
    public partial class BwColor
    {
        [Key]
        public int ColorId { get; set; }
        [StringLength(25)]
        public string ColorDesc { get; set; }
        [StringLength(15)]
        public string IconClass { get; set; }

        public virtual ICollection<TfItemsGroup> TfItemsGroups { get; set; }
    }
}
