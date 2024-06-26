using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("_WindowsServices_Error_Test")]
    public partial class WindowsServicesErrorTest
    {
        [Key]
        public int ErrorId { get; set; }
        public string Msg { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
    }
}
