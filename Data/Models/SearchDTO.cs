namespace Kubona.Data.Models
{
    public class SearchDTO
    {
        
        public int? ItemGroupId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? NumAvailable { get; set; }
        public string? Image1Url { get; set; }
        public decimal? InternetPrice { get; set; }
        public decimal? StorePrice { get; set; }
        //public string? SimilarId { get; set; }
        public string? SizeDesc { get; set; }
        public string? DestinationUrl { get; set; }

        public SearchDTO(int itemGroupId, string title, string description, int numAvailable, string image1Url, decimal internetPrice, decimal storePrice, string sizeDesc,string destinationUrl)
        {
            ItemGroupId = itemGroupId;
            Title = title;
            Description = description;
            NumAvailable = numAvailable;
            Image1Url = image1Url;
            InternetPrice = internetPrice;
            StorePrice = storePrice;
            //SimilarId = similarId;
            SizeDesc = sizeDesc;
            DestinationUrl = destinationUrl;
        }

        public SearchDTO()
        {
        }
    }
}
