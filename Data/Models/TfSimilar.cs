using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Kubona.Data.Models
{
    [Table("TF_Similar")]
    public partial class TfSimilar
    {
        [Key]
        public int Id { get; set; }
        public string SimilarId { get; set; }
        public int ProductId { get; set; }

        //public virtual ICollection<TfItemsGroup> TfItemsGroups { get; set; }
    }
}
