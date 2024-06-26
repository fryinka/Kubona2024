

namespace Kubona.Data.Models
{
    public class CheckOutUserDTO
    {
        public CheckOutUserDTO() { }
        public string source { get; set; }
        public string customerGSM { get; set; }
        public decimal total { get; set; }
        public string gclid { get; set; }
        public string fbclid { get; set; }
        public bool exist { get; set; }
        public int paymentOption { get; set; }
    }

    public class CheckOutDTO
    {
        public CheckOutDTO() { }
        public string whatsAppUrl { get; set; }
        public int orderId { get; set; }

    
    }
}
