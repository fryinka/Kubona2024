using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using Kubona.Data.Helper;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherColorsController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public OtherColorsController(BuyAWatchContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherColorsDTO>>> GetOtherColors(string similarId, int productId = 0)
        {
            if (similarId == null)
            {
                similarId = "Random";
            }
                return await _context.TfItemsGroups
                    .Where(c => c.SimilarId == similarId && c.NumAvailable > 0 && (c.ItemGroupId != productId))
                    .Select(c => new OtherColorsDTO
                    {
                        title = c.BwColor.ColorDesc,
                        mobileImageUrl = c.MobileImageUrl,
                        urlId = URLHelper.GetMainURLPath("https://localhost:44397", "category", c.Title, c.ItemGroupId.ToString()),
                        productId = c.ItemGroupId,
                        internetPrice = c.Internetprice
                    })
                    .ToListAsync();
          

        }

        [HttpGet("ProdColors")]
        public async Task<ActionResult<IEnumerable<OtherColorsDTO>>> GetOtherProdColors(string similarId)
        {
            if (similarId == null)
            {
                similarId = "Random";
            }
            return await _context.TfItemsGroups
                .Where(c => c.SimilarId == similarId && c.NumAvailable > 0)
                .Select(c => new OtherColorsDTO
                {
                    title = c.BwColor.ColorDesc,
                    mobileImageUrl = c.MobileImageUrl,
                    urlId = URLHelper.GetMainURLPath("https://localhost:44397", "category", c.Title, c.ItemGroupId.ToString()),
                    productId = c.ItemGroupId,
                    internetPrice = c.Internetprice
                })
                .ToListAsync();


        }



    }
}
