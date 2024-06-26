using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_User_Keyword")]
    public partial class TfUserKeyword
    {
        [Key]
        [Column("GSM")]
        [StringLength(13)]
        public string Gsm { get; set; }
        [StringLength(4)]
        public string Keyword { get; set; }
        [Column("addedDate", TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
    }
}
