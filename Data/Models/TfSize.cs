using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kubona.Data.Models
{
    [Table("TF_Sizes")]
    public partial class TfSize
    {
        [Key]
        public int SizeId { get; set; }
        public int? SizeCode { get; set; }
        [Required]
        [StringLength(12)]
        public string SizeDesc { get; set; }
    }
}
