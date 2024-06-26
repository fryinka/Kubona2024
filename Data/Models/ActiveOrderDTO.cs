using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class ActiveOrderDTO
    {

        public ActiveOrderDTO() { }
        public string userId { set; get; }
        public int orderId { set; get; }
        public decimal? totalValue { set; get; }
        public int totalItems { set; get; }
    }
}
