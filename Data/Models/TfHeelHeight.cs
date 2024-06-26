using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Kubona.Data.Models
{
    [Table("TF_HeelHeight")]
    public partial class TfHeelHeight
    {
        [Key]
        public int HeelHeightId { get; set; }
        public string Desc { get; set; }

        public virtual ICollection<TfItemsGroup> TfItemsGroups { get; set; }
    }
}
