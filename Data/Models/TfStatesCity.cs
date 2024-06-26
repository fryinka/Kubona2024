using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_States_Cities")]
    public partial class TfStatesCity
    {
        [Key]
        public int CityId { get; set; }
        [StringLength(45)]
        public string City { get; set; }
        public int? StateId { get; set; }
        [Column("CODAvailable")]
        public bool? Codavailable { get; set; }
        [Column(TypeName = "money")]
        public decimal? DeliveryCharges { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty(nameof(TfStatesDeliveryCharge.TfStatesCities))]
        public virtual TfStatesDeliveryCharge State { get; set; }
    }
}
