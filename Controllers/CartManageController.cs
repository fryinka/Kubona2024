using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using ReturnTrue.AspNetCore.Identity.Anonymous;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartManageController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public CartManageController(BuyAWatchContext context)
        {
            _context = context;
        }

      
        [HttpGet("{orderItemId}")]
        public async Task<ActionResult<ActiveOrderDTO>> GetCartManageAfterDelete(int orderItemId)
        {
            string userId = null;
            int orderId = 0;

        
            IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
            if (feature != null)
            {
                userId = feature.AnonymousId;
                orderId = getOrderId(userId);
                await DeleteOrderItem(orderItemId, orderId);
            }

            return await _context.TfOrderProductLoggers
                  .Where(m => m.CurrentStatus < (int?)kubonaEnums.orderLoggerStatus.checkout)
                  .Join(_context.TfOrderProducts.Where(n => n.UserId == userId), m => m.OrderId, n => n.OrderId,
                  (o, m) => new ActiveOrderDTO
                  {
                      orderId = o.OrderId,
                      userId = m.UserId,
                      totalValue = m.OrderAmount,
                      totalItems = m.NumOfItems
                  }
                  ).FirstOrDefaultAsync();
        }

    
        private async Task<bool> DeleteOrderItem(int id, int orderId)
        {
            var tfProductOrderItem = await _context.TfProductOrderItems.Where(m => m.OrderItemId == id && m.OrderId == orderId).FirstOrDefaultAsync();
            var tfOrderProduct = await _context.TfOrderProducts.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (tfProductOrderItem == null)
            {
                return false;
            }

             _context.TfProductOrderItems.Remove(tfProductOrderItem);
            await _context.SaveChangesAsync();
            var numOfItems = _context.TfProductOrderItems.Where(e => e.OrderId == orderId).Sum(p => p.Quantity);
            var orderTotal = _context.TfProductOrderItems.Where(m => m.OrderId == orderId)
                .Join(_context.TfItemsGroups, m => m.ProductId, n => n.ItemGroupId, (m, n) => new
                {
                    quantity = m.Quantity,
                    internetPrice = n.Internetprice
                }).Sum(p => p.quantity * p.internetPrice);
            tfOrderProduct.OrderAmount = orderTotal;
            tfOrderProduct.NumOfItems = numOfItems;
            _context.Entry(tfOrderProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        private int getOrderId(string userId)
        {
            var tfOrderProductLoggers = _context.TfOrderProductLoggers
                  .Where(m => m.CurrentStatus < (int?)kubonaEnums.orderLoggerStatus.checkout)
                  .Join(_context.TfOrderProducts.Where(n => n.UserId == userId), m => m.OrderId, n => n.OrderId,
                  (o, m) => new
                  {
                      orderId = o.OrderId,
                      userId = m.UserId
                  }
                  ).FirstOrDefault();

            if (tfOrderProductLoggers == null)
            {
                return 0;
            }
            else
            {
                return tfOrderProductLoggers.orderId;
            }

        }

    }

}

