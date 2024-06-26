using Kubona.Data.Models;
using Kubona.Data.Snickler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesCurationController : ControllerBase
    {
        private readonly BuyAWatchContext _context;
        public SalesCurationController(BuyAWatchContext context)
        {
            _context = context;
        }

        [HttpGet("GetCustRecommendation")]
        public async Task<ActionResult<CustCurationDetailsDTO>> GetCustRecommendation(string curationId=null)
        {
            if (curationId != null)
            {
                var result = await _context.CrmCurationKeys.Select(x => new CustCurationDetailsDTO()
                {
                    CurationId = x.curationID,
                    CustomerName = x.customerName
                }).Where(x => x.CurationId == curationId).FirstOrDefaultAsync();
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("CuratedList")]
        public async Task<ActionResult<IEnumerable<CuratedForCustomerDTO>>> GetCuratedList(string curationId = null, int pageSize=15)
        {
            ICollection<CuratedForCustomerDTO> curatedList = null;
            if (curationId != null)
            {
                await _context.LoadStoredProc("CRM_CURATION_RECOMMENDATIONS")
                .WithSqlParam("curationId", curationId)
                .WithSqlParam("pageSize", pageSize)
                .ExecuteStoredProcAsync((handler) =>
                {
                    curatedList = handler.ReadToList<CuratedForCustomerDTO>();
                });
                return Ok(curatedList);
            }
            return BadRequest();
        }
    }
}
