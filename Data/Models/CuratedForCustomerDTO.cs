namespace Kubona.Data.Models
{
    public class CuratedForCustomerDTO
    {
        public CuratedForCustomerDTO() { }
        public int ItemgroupId { get; set; }
        public string Title { get; set; }
        public decimal InternetPrice { get; set; }
        public string ImageUrl { get; set; }
        public string destinationUrl { get; set; }
    }
}
