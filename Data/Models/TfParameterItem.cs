using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ParameterItems")]
    public partial class TfParameterItem
    {
        [Key]
        public int ParamId { get; set; }
        [Key]
        public int ProductId { get; set; }
    }
}
