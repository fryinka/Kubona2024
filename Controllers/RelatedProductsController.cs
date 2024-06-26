using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Kubona.Data.Models;
using ReturnTrue.AspNetCore.Identity.Anonymous;
using Kubona.Data.Helper;
using Kubona.Data.Snickler;


namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedProductsController : ControllerBase
    {
        private readonly BuyAWatchContext _context;
        private readonly IConfiguration _config;

        public RelatedProductsController(BuyAWatchContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatedProductsDTO>>> GetRelatedProducts(int departmentId = 0, int itemGroupId = 0, int pageSize = 8)
        {

            string userId = null;
                    IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
            if (feature != null)
            {
                userId = feature.AnonymousId;
            }
            ICollection<RelatedProductsDTO> qResults = null;

            await _context.LoadStoredProc("TF_RECOMMENDATION")
                .WithSqlParam("userId",userId)
                .WithSqlParam("departmentId", departmentId)
                .WithSqlParam("itemGroupId", itemGroupId )
                .WithSqlParam("pageSize", pageSize)
                .ExecuteStoredProcAsync((handler) =>
                {
                    qResults = SetDestinationUrl(handler.ReadToList<RelatedProductsDTO>());

                });
            return Ok(qResults);

        }

        private ICollection<RelatedProductsDTO> SetDestinationUrl(ICollection<RelatedProductsDTO> MList)
        {
            foreach (RelatedProductsDTO qResult in MList)
            {
                qResult.urlId = URLHelper.GetMainURLPath("https://localhost:44397", "product", qResult.title, qResult.itemgroupId.ToString());
            }

            return MList;
        }

    }
}
