using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("BAG_RequestForm")]
    public partial class BagRequestForm
    {
        [Key]
        public int RequestId { get; set; }
        [StringLength(35)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        public string Comments { get; set; }
        [StringLength(15)]
        public string EstimatedGuest { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
