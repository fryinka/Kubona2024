using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using System.Data.Entity;
using ReturnTrue.AspNetCore.Identity.Anonymous;
using Kubona.Data.Helper;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecentlyViewedController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public RecentlyViewedController(BuyAWatchContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecentlyViewedDTO>>> GetRecentlyViewed(int pageSize = 5)
        {
            string userId = null;
            IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
            if (feature != null)
            {
                userId = feature.AnonymousId;
            }
            return await _context.TFItemsGroupViewHistories.Where(v => v.UserId == userId).OrderByDescending(c => c.ViewDate).Take(pageSize)
                .Join(_context.TfItemsGroups, o => o.ItemId, m => m.ItemGroupId, (o, m) =>
                new RecentlyViewedDTO
                {
                    itemId = o.ItemId,
                    title = m.Title,
                    imageUrl = m.HighResolutionUrl,
                    internetPrice = m.Internetprice,
                    urlId = URLHelper.GetMainURLPath("https://localhost:44397", "product", m.Title, m.ItemGroupId.ToString()),
                    viewDate = o.ViewDate


                })
                .Take(pageSize)
                 .ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<int>> PostRecentlyViewed(TfItemsgroupViewHistory viewItem)
        {
            viewItem.ViewDate = DateTime.Now;
           
            IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
           
            if (feature != null)
            {
                viewItem.UserId = feature.AnonymousId;
            }

            if (!TfItemsgroupViewHistoryExists(viewItem))
            {
                if(TfItemsGroupExists(viewItem.ItemId))
                {
                    _context.TFItemsGroupViewHistories.Add(viewItem);
                    await _context.SaveChangesAsync();
                }
                
            }
            else
            {
                var pViewItem = _context.TFItemsGroupViewHistories.Where(e => e.ItemId == viewItem.ItemId && e.UserId == viewItem.UserId).FirstOrDefault();
                pViewItem.ViewDate = viewItem.ViewDate;
                pViewItem.NumOfViews = pViewItem.NumOfViews + 1;
                _context.Entry(pViewItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return 2;
        }


        [HttpGet("CustomerLookup/{GSM}")]
        public async Task<ActionResult<IEnumerable<CustomerHistoryDTO>>> GetCustomerDetails(int GSM)
        {
            var final = new List<CustomerHistoryDTO>();
            var customer = (from a in _context.TfInvoicesLogs
                            from b in _context.TfItemsgroupSizes
                            from e in _context.TfSizes
                            from c in _context.TfStatesDeliveryCharges
                            from f in _context.TfItemsGroups
                            where a.LocationId == c.StateId && a.TrackingId == b.TrackingId && b.SizeCode == e.SizeCode && f.ItemGroupId==b.ItemGroupId
                            select new CustomerHistoryDTO
                            {
                                InvoiceDate = a.InvoiceDate,
                                InvoiceId = a.InvoiceId,
                                TrackingId = a.TrackingId,
                                SizeDesc = e.SizeDesc,
                                Quantity = b.Quantity,
                                Title = a.Title,
                                InternetPrice = a.InternetPrice,
                                Location = c.StateDesc,
                                InvoiceStatus = a.Invoicestatus,
                                Gsm = a.Gsm,
                                ImageUrl = f.MobileImageUrl,
                                ShippedDate = a.ShippedDate,
                                productId = a.Itemgroupid,
                                OrderId = a.OrderId
                            }).ToList();
            foreach (var x in customer)
            {
                if (x.OrderId == GSM)
                {
                    final.Add(x);
                }
            }
            final.OrderByDescending(x => x.InvoiceDate);

            return final;
        }



        private bool TfItemsgroupViewHistoryExists(TfItemsgroupViewHistory tfItemsView)
        {
            return _context.TFItemsGroupViewHistories.Any(e => e.ItemId == tfItemsView.ItemId && e.UserId == tfItemsView.UserId);
        }

        private bool TfItemsGroupExists(int itemgroupId)
        {
            return _context.TfItemsGroups.Any(e => e.ItemGroupId == itemgroupId);
        }
    }
}