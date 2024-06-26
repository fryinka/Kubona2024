using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Keyless]
    [Table("_Temp_Deactivate_Fix")]
    public partial class TempDeactivateFix
    {
        public int? OldItemGroupId { get; set; }
        public int? NewItemGroupId { get; set; }
    }
}
