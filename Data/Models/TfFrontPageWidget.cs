using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_FrontPage_Widgets")]
    public partial class TfFrontPageWidget
    {
        [Key]
        public int WidgetId { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CollectionId { get; set; }
        public int? CategoryId { get; set; }
        public int? PageSize { get; set; }
        public int? CategoryPageSize { get; set; }
        public int? UserId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column("brandId")]
        public int? BrandId { get; set; }
        [Column("colorId")]
        public int? ColorId { get; set; }
    }
}
