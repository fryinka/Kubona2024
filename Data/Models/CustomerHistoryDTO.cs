using System;

namespace Kubona.Data.Models
{
    public class CustomerHistoryDTO
    {
        public CustomerHistoryDTO() { }
        public DateTime? InvoiceDate { get; set; }
        public int? InvoiceId { get; set; }
        public string TrackingId { get; set; }
        public string SizeDesc { get; set; }
        public int? Quantity { get; set; }
        public string Title { get; set; }
        public decimal InternetPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? InvoiceStatus { get; set; }
        public string Gsm { get; set; }
        public int? productId { get; set; }
        public int? OrderId { get; set; }
    }
}
