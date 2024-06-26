using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ExchangeRequest")]
    public partial class TfExchangeRequest
    {
        [Key]
        [Column("exchangeId")]
        public int ExchangeId { get; set; }
        [Required]
        [Column("CustomerGSM")]
        [StringLength(13)]
        public string CustomerGsm { get; set; }
        [Column("invoiceNumber")]
        [StringLength(25)]
        public string InvoiceNumber { get; set; }
        [Column("stateId")]
        public int StateId { get; set; }
        public int PaymentType { get; set; }
        [Column("dateReceived", TypeName = "datetime")]
        public DateTime DateReceived { get; set; }
        [Column("dateRequested", TypeName = "datetime")]
        public DateTime DateRequested { get; set; }
        public int StatusId { get; set; }
        [Column("reasonForExchange")]
        public int? ReasonForExchange { get; set; }
        [Column("pickupOption")]
        public int? PickupOption { get; set; }
        [Column("returnModeId")]
        public int? ReturnModeId { get; set; }
    }
}
