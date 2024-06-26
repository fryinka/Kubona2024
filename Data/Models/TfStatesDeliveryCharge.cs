using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_States_DeliveryCharges")]
    public partial class TfStatesDeliveryCharge
    {
        public TfStatesDeliveryCharge()
        {
            TfStatesCities = new HashSet<TfStatesCity>();
        }

        [Key]
        public int StateId { get; set; }
        [Required]
        [StringLength(50)]
        public string StateDesc { get; set; }
        [Column(TypeName = "money")]
        public decimal DeliveryCharges { get; set; }

        [InverseProperty(nameof(TfStatesCity.State))]
        public virtual ICollection<TfStatesCity> TfStatesCities { get; set; }
    }
}
