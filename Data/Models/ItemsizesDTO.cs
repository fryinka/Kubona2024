namespace Kubona.Data.Models
{
    public class ItemsizesDTO
    {
     public ItemsizesDTO() { }
     public int itemGroupSizeId { get; set; }
     public int itemGroupId { get; set; }
     public string sizeDesc { get; set; }   
     public string trackingId { get; set; }
     public int? quantity { get; set; }
     public int? sizeCode { get; set; }
    }
}
