

namespace Kubona.Data.Models
{
    public class OrderSubmitDTO
    {
        public OrderSubmitDTO() { }

        public string userId { get; set; }

        public int productId { get; set; }

        public int itemgroupSizeId { get; set; }
    }
}
