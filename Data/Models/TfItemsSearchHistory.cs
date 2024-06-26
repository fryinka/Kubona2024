using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Items_SearchHistory")]
    public partial class TfItemsSearchHistory
    {
        [Key]
        public int SearchIndex { get; set; }
        [StringLength(50)]
        public string SearchCriteria { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
        public int? UserId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
