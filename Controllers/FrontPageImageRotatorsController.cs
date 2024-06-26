using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using Kubona.Data.Helper;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontPageImageRotatorsController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public FrontPageImageRotatorsController(BuyAWatchContext context)
        {
            _context = context;
        }

        // GET: api/FrontPageImageRotators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrontPageDTO>>> GetTfFrontPageImageRotators(int rotatorId = 2, int pageSize = 12)
        {
           

            var myResult = await _context.TfFrontPageImageRotators
                .Where(b => b.RotatorId == rotatorId && b.Position > 0)
                .Take(pageSize)
                .OrderBy(b => b.Position)
                .ToListAsync();

            return Ok(ConvertRawUrltoRouterUrl(myResult));

        }

        private ICollection<FrontPageDTO> ConvertRawUrltoRouterUrl(ICollection<TfFrontPageImageRotator> rotatorList)
        {
            List<FrontPageDTO> qResults = new List<FrontPageDTO>();
            foreach (TfFrontPageImageRotator mItem in rotatorList)
            {
                FrontPageDTO cItem = new FrontPageDTO
                {
                    ImageTitle = mItem.ImageTitle,
                    Imageurl = mItem.ImageUrl,
                    Summary = mItem.Summary
                };

                string[] Iurl = URLHelper.SplitUrl(URLHelper.CleanExternalUrl(mItem.DestinationUrl), '/');
                if (Iurl.Length > 1)
                {
                    cItem.RouteUrl = Iurl[1];
                    if (Iurl.Length > 2)
                    {
                        cItem.RouteId = Iurl[2];
                    }
                }

                qResults.Add(cItem);
      
            }
            return qResults;
        }
    }
}
