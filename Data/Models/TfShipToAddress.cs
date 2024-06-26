using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ShipToAddress")]
    public partial class TfShipToAddress
    {
        [Key]
        public int ShipToId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }
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
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column("OrderGSM")]
        [StringLength(15)]
        public string OrderGsm { get; set; }
        [StringLength(100)]
        public string OrderName { get; set; }
        [Column("hearaboutus")]
        public int? Hearaboutus { get; set; }
        [Column("AlternativeGSM")]
        [StringLength(15)]
        public string AlternativeGsm { get; set; }
    }
}
