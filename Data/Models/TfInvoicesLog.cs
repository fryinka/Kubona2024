using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_InvoicesLog")]
    public partial class TfInvoicesLog
    {
        [Key]
        [Column("invoicesLogId")]
        public int InvoicesLogId { get; set; }
        public int InvoicesItemId { get; set; }
        [StringLength(50)]
        public string SoldBy { get; set; }
        public int? ChannelId { get; set; }
        [StringLength(10)]
        public string TrackingId { get; set; }
        [Column("GSM")]
        [StringLength(11)]
        public string Gsm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InvoiceDate { get; set; }
        [Column(TypeName = "money")]
        public decimal InternetPrice { get; set; }
        public int? Quantity { get; set; }
        public int? ContactId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column("departmentId")]
        public int? DepartmentId { get; set; }
        [Column("title")]
        [StringLength(80)]
        public string Title { get; set; }
        [Column("itemgroupid")]
        public int? Itemgroupid { get; set; }
        [Column("locationId")]
        public int? LocationId { get; set; }
        [Column("invoiceId")]
        public int? InvoiceId { get; set; }
        [Column("invoicestatus")]
        public int? Invoicestatus { get; set; }
        [Column("shippedDate")]
        public DateTime? ShippedDate { get; set; }
        [Column("orderId")]
        public int? OrderId { get; set; }
    }
}
