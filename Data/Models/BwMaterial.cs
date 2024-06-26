using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("BW_Materials")]
    public partial class BwMaterial
    {
        [Key]
        public int MaterialId { get; set; }
        [StringLength(25)]
        public string MaterialName { get; set; }

        //public virtual ICollection<TfItemsGroup> TfItemsGroups { get; set; }
    }
}
