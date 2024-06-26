using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using Kubona.Data.Snickler;
using ReturnTrue.AspNetCore.Identity.Anonymous;
using Kubona.Data.Helper;
using System.Net.Sockets;
using System.Net;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public OrderController(BuyAWatchContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemsDTO>>> GetOrderItems(int pageNumber = 0, int pageSize = 50) 
        {
            int orderId = 0;
            string userId = null;

            IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
            if (feature != null)
            {
                userId = feature.AnonymousId;
            }

            if (userId != null)
            {
                var currentOrder = await _context.TfOrderProductLoggers
                  .Where(m => m.CurrentStatus < 5)
                  .Join(_context.TfOrderProducts.Where(n => n.UserId == userId), m => m.OrderId, n => n.OrderId, (o, m) =>
                new TfOrderProductLogger
                {
                    OrderId = m.OrderId
                }).FirstOrDefaultAsync();
               
                if (currentOrder != null)
                {
                    orderId = currentOrder.OrderId;
                };
            };

            ICollection<OrderItemsDTO> qResults = null;
           
            await _context.LoadStoredProc("TF_Order_Product_GetByOrderId")
                 .WithSqlParam("orderId", orderId)
                 .WithSqlParam("pageNumber", pageNumber)
                 .WithSqlParam("pageSize", pageSize)
                 .ExecuteStoredProcAsync((handler) =>
                 {
                     qResults = SetDestinationUrl(handler.ReadToList<OrderItemsDTO>());
                 });
            return Ok(qResults);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveOrderDTO>> GetOrderItem(string id)
        {
            string userId = null;

        
            IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
            if (feature != null)
            {
                userId = feature.AnonymousId;
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
                  }).FirstOrDefaultAsync();
        }


        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<int>> PostTfProductOrderItem(OrderSubmitDTO orderItem)
        {
            int productId = orderItem.productId;
            string userId = null;

            int itemgroupSizeId = orderItem.itemgroupSizeId;
            string ipv4Address = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string ipAddress = (IsValidIPv4(ipv4Address) && ipv4Address != "0.0.0.1") ? ipv4Address : "127.0.0.1";


            IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
            if (feature != null)
            {
                userId = feature.AnonymousId;
            }

            int orderId = getOrderId(userId);

            if (orderId == 0)
            {
                string expressCode = System.Guid.NewGuid().ToString("N").Substring(0, 5);
                string transactionId = System.Guid.NewGuid().ToString("N").Substring(0, 16);
                return await InsertFirstItem(productId, userId, 1, DateTime.Now, 5, 0, expressCode, transactionId, ipAddress, itemgroupSizeId);
            }
            else
            {
                var gsm = getUserGSM(orderId);
                var currentStatus = kubonaEnums.orderLoggerStatus.identified;
                if (gsm == null)
                {
                    currentStatus = kubonaEnums.orderLoggerStatus.pending;
                }
                return await InsertMoreItems(productId, itemgroupSizeId, orderId, 1, DateTime.Now, (int)kubonaEnums.orderLoggerStatus.checkout, (int)currentStatus);
            }
        }

    

        private async Task<ActionResult<int>> InsertFirstItem(int productId, string userId, int quantity, DateTime dateAdded, int checkoutStatus, 
            int currentStatus, string expressCode, string transactionId = null, string ipAddress = null, int itemgroupSizeId = 0)
        {
            int orderId = 0;

            if (!onGoingOrderExists(userId))
            {
                if (availableQuantity(productId, itemgroupSizeId) > 0)
                {
                    TfOrderProductLogger tfOrderProductLogger = new TfOrderProductLogger
                    {
                        TransactionId = transactionId,
                        ExpressCode = expressCode,
                        CurrentStatus = currentStatus,
                        CheckoutDate = DateTime.Now.AddHours(2)
                    };

                    _context.TfOrderProductLoggers.Add(tfOrderProductLogger);
                    await _context.SaveChangesAsync();
                    orderId = tfOrderProductLogger.OrderId;


                    var cTfitemsgroup = _context.TfItemsGroups.Where(e => e.ItemGroupId == productId).FirstOrDefault();

                    TfOrderProduct tfOrderProduct = new TfOrderProduct
                    {
                        OrderId = orderId,
                        UserId = userId,
                        AddedByUserId = 0,
                        AddedDate = DateTime.Now,
                        Ipaddress = ipAddress,
                        NumOfItems = 1,
                        OrderAmount = cTfitemsgroup.Internetprice,
                        SyncStatus = 0
                    };

                    _context.TfOrderProducts.Add(tfOrderProduct);
                    await _context.SaveChangesAsync();

                    if (!productOrderItemExists(productId, orderId, itemgroupSizeId))
                    {
                        TfProductOrderItem tfProductOrderItem = new TfProductOrderItem
                        { 
                            OrderId = orderId,
                            ProductId = productId,
                            ProductTitle = cTfitemsgroup.Title,
                            UnitPrice = cTfitemsgroup.Internetprice,
                            Quantity = 1,
                            OrderStatus = currentStatus,
                            ProductType = cTfitemsgroup.Producttype,
                            TransactionId = transactionId,
                            OfferPrice = cTfitemsgroup.OfferPrice,
                            Expirydate = cTfitemsgroup.ExpiryDate,
                            ItemGroupSizeId = itemgroupSizeId
                        };
                        _context.TfProductOrderItems.Add(tfProductOrderItem);
                       await _context.SaveChangesAsync();
                           
                    }
                }
            }
            return orderId;
        }

        private async Task<ActionResult<int>> InsertMoreItems(int productId, int itemgroupSizeId, int orderId, int quantity, DateTime dateAdded, int checkoutStatus, int currentStatus)
        {
            var quantityAvailable = availableQuantity(productId, itemgroupSizeId);
            if (quantityAvailable > 0)
            {
                var cTfitemsgroup = _context.TfItemsGroups.Where(e => e.ItemGroupId == productId).FirstOrDefault();
                var transactionId = _context.TfOrderProductLoggers.Where(e => e.OrderId == orderId).FirstOrDefault().TransactionId;

                if (!productOrderItemExists(productId,orderId,itemgroupSizeId))
                {
                    TfProductOrderItem tfProductOrderItem = new TfProductOrderItem
                    {
                        OrderId = orderId,
                        ProductId = productId,
                        ProductTitle = cTfitemsgroup.Title,
                        UnitPrice = cTfitemsgroup.Internetprice,
                        Quantity = quantity,
                        OrderStatus = currentStatus,
                        ProductType = cTfitemsgroup.Producttype,
                        TransactionId = transactionId,
                        OfferPrice = cTfitemsgroup.OfferPrice,
                        Expirydate = cTfitemsgroup.ExpiryDate,
                        ItemGroupSizeId = itemgroupSizeId
                    };
                    _context.TfProductOrderItems.Add(tfProductOrderItem);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var cTfProductOrderItems = _context.TfProductOrderItems.Where(e => e.ProductId == productId && e.OrderId == orderId && e.ItemGroupSizeId == itemgroupSizeId).FirstOrDefault();
            
                    if ((quantity+cTfProductOrderItems.Quantity) <= quantityAvailable)
                    {
                        cTfProductOrderItems.Quantity = cTfProductOrderItems.Quantity + quantity;
                        _context.Entry(cTfProductOrderItems).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }

                var numOfItems = _context.TfProductOrderItems.Where(e => e.OrderId == orderId).Sum(p => p.Quantity);
                var orderTotal = _context.TfProductOrderItems
                                        .Where(m => m.OrderId == orderId)
                                        .Join(_context.TfItemsGroups, m => m.ProductId, n => n.ItemGroupId, (m, n) =>
                                    new
                                    {
                                        quantity = m.Quantity,
                                        internetPrice = n.Internetprice
                                    }).Sum(p => p.quantity * p.internetPrice);

                var fTfOrderProduct = _context.TfOrderProducts.Where(e => e.OrderId == orderId).FirstOrDefault();
                if (fTfOrderProduct != null)
                {
                    fTfOrderProduct.NumOfItems = numOfItems;
                    fTfOrderProduct.OrderAmount = orderTotal;
                    _context.Entry(fTfOrderProduct).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                var fTfOrderProductLogger = _context.TfOrderProductLoggers.Where(e => e.OrderId == orderId).FirstOrDefault();
                if (fTfOrderProductLogger != null)
                {
                    fTfOrderProductLogger.CheckoutDate = DateTime.Now.AddHours(3);
                    _context.Entry(fTfOrderProductLogger).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

            }
            return orderId;

        }


        private bool TfProductOrderItemExists(int id)
        {
            return _context.TfProductOrderItems.Any(e => e.OrderItemId == id);
        }

        private bool productOrderItemExists(int productId, int orderId, int sizeId)
        {
            return _context.TfProductOrderItems.Any(e => e.ProductId == productId && e.OrderId == orderId && e.ItemGroupSizeId == sizeId);
        }

      
        private bool onGoingOrderExists(string userId)
        {
            return _context.TfOrderProductLoggers
                  .Where(m => m.CurrentStatus < (int?)kubonaEnums.orderLoggerStatus.checkout)
                  .Join(_context.TfOrderProducts.Where(n => n.UserId == userId), m => m.OrderId, n => n.OrderId,
                  (o, m) => new
                  {
                      orderId = o.OrderId,
                      userId = m.UserId
                  }
                  ).Any(e => e.userId == userId);
                  
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

        private string getUserGSM(int orderId)
        {
            var aTempVar = _context.TfOrderProductLoggers
                  .Where(m => m.OrderId == orderId).FirstOrDefault();

            if (aTempVar == null)
            {
                return null;
            }
            else
            {
                return aTempVar.CustomerGsm;
            }

        }


        private int? availableQuantity(int productId, int sizeId)
        {
            if (_context.TfItemsgroupSizes.Any(e => e.ItemGroupId == productId && e.ItemGroupSizeId == sizeId))
            {
                return _context.TfItemsgroupSizes.Where(e => (e.ItemGroupId == productId) && (e.ItemGroupSizeId == sizeId)).FirstOrDefault().Quantity;
            }
            else
            {
                if (_context.TfItemsGroups.Any(e => e.ItemGroupId == productId))
                {
                    return _context.TfItemsGroups.Where(e => e.ItemGroupId == productId).FirstOrDefault().NumAvailable;
                }
                else { return 0; }
            }
        }

        private ICollection<OrderItemsDTO> SetDestinationUrl(ICollection<OrderItemsDTO> MList)
        {
            foreach (OrderItemsDTO qResult in MList)
            {
                qResult.categoryId = URLHelper.GetMainURLPath("https://localhost:44397", "category", qResult.departmentName, qResult.departmentId.ToString());
                qResult.productId = URLHelper.GetMainURLPath("https://localhost:44397", "product", qResult.title, qResult.itemGroupId.ToString());
            }

            return MList;
        }

        private static bool IsValidIPv4(string ipAddress)
        {
            if (IPAddress.TryParse(ipAddress, out IPAddress ip))
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) // Ensure it's IPv4
                {
                    return true;
                }
            }
            return false;
        }

    }

}

