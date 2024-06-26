using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_RelatedCollections")]
    public partial class TfRelatedCollection
    {
        [Key]
        public int CollectionId { get; set; }
        [Key]
        [Column("relatedCollectionId")]
        public int RelatedCollectionId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        public int? Strength { get; set; }
    }
}
