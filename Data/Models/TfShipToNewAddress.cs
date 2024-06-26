using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ShipToNewAddress")]
    public partial class TfShipToNewAddress
    {
        [Key]
        [Column("addressId")]
        public int AddressId { get; set; }
        [Required]
        [StringLength(100)]
        public string DeliverTo { get; set; }
        [StringLength(100)]
        public string Address1 { get; set; }
        [StringLength(50)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(25)]
        public string NearestBusStop { get; set; }
        [StringLength(25)]
        public string NearestLandMark { get; set; }
        [StringLength(15)]
        public string DaytimePhone { get; set; }
        [StringLength(15)]
        public string PreferredDeliveryTime { get; set; }
        public int? Country { get; set; }
        public int? OfficeResidential { get; set; }
        public int State { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [Column("alternativePhone")]
        [StringLength(15)]
        public string AlternativePhone { get; set; }
    }
}
