using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class OrderItemsDTO
    {
        public OrderItemsDTO() { }
        public int orderItemId { get; set; }
        public string mobileImageUrl { get; set; }
        public int itemGroupId { get; set; }
        public int quantity { get; set; }
        public string title { get; set; }
        public decimal internetPrice { get; set; }

        public int numAvailable { get; set; }
        public int departmentId { get; set; }
        public string size { get; set; }
        public string trackingId { get; set; }
        public string departmentName { get; set; }
        public string productId { get; set; }
        public string categoryId { get; set; }
        public string color { get; set; }

    }
}
