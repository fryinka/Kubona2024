using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using Kubona.Data.Helper;
using System.Web;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TfMenuLinksController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public TfMenuLinksController(BuyAWatchContext context)
        {
            _context = context;
        }

        // GET: api/TfMenuLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuLinksDTO>>> GetTfMenuLinks(int departmentId = 0, int categoryId = 0, int pageSize = 5)
        {
            var myResult = await _context.TfMenuLinks
                .Where(c => (departmentId == 0 || c.DepartmentId == departmentId) && 
                (categoryId == 0 || c.CategoryId == categoryId))
                .OrderByDescending(c => c.DateAdded)
                .Take(pageSize)
                .ToListAsync();
            return Ok(ConvertRawUrltoRouterUrl(myResult));
        }

        // GET: api/TfMenuLinks/5
        private ICollection<MenuLinksDTO> ConvertRawUrltoRouterUrl(ICollection<TfMenuLink> rotatorList)
        {
            List<MenuLinksDTO> qResults = new List<MenuLinksDTO>();
            foreach (TfMenuLink mItem in rotatorList)
            {
                MenuLinksDTO cItem = new MenuLinksDTO
                {
                    ShortTitle = mItem.ShortTitle,
                    LinkId = mItem.LinkId
                   
                };

                string[] Iurl = URLHelper.SplitUrl(URLHelper.CleanExternalUrl(mItem.DestinationUrl), '/');
                if (Iurl.Length > 1)
                {
                    cItem.RouteUrl = string.Format("/{0}",Iurl[1]);
                    if (Iurl.Length > 2)
                    {
                        cItem.RouteId = HttpUtility.HtmlDecode(Iurl[2]);
                    }
                }

                qResults.Add(cItem);

            }
            return qResults;
        }
    }
}
