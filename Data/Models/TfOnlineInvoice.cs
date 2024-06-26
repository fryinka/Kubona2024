using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_OnlineInvoices")]
    public partial class TfOnlineInvoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        [Column("CustomerGSM")]
        [StringLength(15)]
        public string CustomerGsm { get; set; }
        [Column("AlternativeGSM")]
        [StringLength(15)]
        public string AlternativeGsm { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(350)]
        public string CustomerAddress { get; set; }
        public int StateId { get; set; }
        [Required]
        public string TrackingIds { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [StringLength(6)]
        public string DownloadCode { get; set; }
        public int? DownloadStatus { get; set; }
        public string OrderIds { get; set; }
        [Column("city")]
        [StringLength(50)]
        public string City { get; set; }
        [Column("source")]
        [StringLength(25)]
        public string Source { get; set; }
        [Column("shipAfterDate", TypeName = "datetime")]
        public DateTime? ShipAfterDate { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("invoiceTypeId")]
        public int? InvoiceTypeId { get; set; }
    }
}
