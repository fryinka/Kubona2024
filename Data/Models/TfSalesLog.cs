using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_SalesLog")]
    public partial class TfSalesLog
    {
        [Key]
        public int SalesLogId { get; set; }
        public int ReceiptItemId { get; set; }
        [StringLength(50)]
        public string SoldBy { get; set; }
        public int? ChannelId { get; set; }
        [StringLength(10)]
        public string TrackingId { get; set; }
        [Column("GSM")]
        [StringLength(11)]
        public string Gsm { get; set; }
        [Column("purchaseDate", TypeName = "datetime")]
        public DateTime? PurchaseDate { get; set; }
        public int? CashBackValue { get; set; }
        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }
        public int? Quantity { get; set; }
        public int? ContactId { get; set; }
        [Column("dateAdded", TypeName = "datetime")]
        public DateTime? DateAdded { get; set; }
        [Column("cashBackProcessed")]
        public bool? CashBackProcessed { get; set; }
        public int? CollectionId { get; set; }
        [Column("departmentId")]
        public int? DepartmentId { get; set; }
        [Column("collectionName")]
        [StringLength(80)]
        public string CollectionName { get; set; }
        [Column("title")]
        [StringLength(80)]
        public string Title { get; set; }
        [Column("itemgroupid")]
        public int? Itemgroupid { get; set; }
    }
}
