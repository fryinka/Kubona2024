using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Order_Product_Logger")]
    public partial class TfOrderProductLogger
    {
        [Key]
        public int OrderId { get; set; }
        [StringLength(50)]
        public string TransactionId { get; set; }
        public int? OrderType { get; set; }
        [StringLength(5)]
        public string ExpressCode { get; set; }
        public int? CurrentStatus { get; set; }
        [StringLength(20)]
        public string DeviceSource { get; set; }
        public int? PaymentMode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }
        [Column(TypeName = "money")]
        public decimal? PaymentAmount { get; set; }
        [Column("PaymentIPAddress")]
        [StringLength(25)]
        public string PaymentIpaddress { get; set; }
        [Column("isActivated")]
        public bool? IsActivated { get; set; }
        [Column("downloadSyncStatus")]
        public int? DownloadSyncStatus { get; set; }
        [StringLength(30)]
        public string TellerId { get; set; }
        [StringLength(30)]
        public string TellerNumber { get; set; }
        [Column("customerGSM")]
        [StringLength(13)]
        public string CustomerGsm { get; set; }
        [Column("cityId")]
        public int? CityId { get; set; }
        [Column("codeconfirmed")]
        public bool? Codeconfirmed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CheckoutDate { get; set; }
        [Column("onlineNotes")]
        [StringLength(50)]
        public string OnlineNotes { get; set; }
        [Column("stateId")]
        public int? StateId { get; set; }
        [Column("receiptViews")]
        public int? ReceiptViews { get; set; }
    }
}
