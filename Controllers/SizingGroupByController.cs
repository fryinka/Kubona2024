using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kubona.Data.Models;
using Kubona.Data.Helper;
using Kubona.Data.Snickler;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizingGroupByController : ControllerBase
    {

        private readonly BuyAWatchContext _context;
        
      
        public SizingGroupByController(BuyAWatchContext context)
        {
            _context = context;
        }


        [HttpGet("{urlId}")]
        public async Task<ActionResult<IEnumerable<SizingGroupDTO>>> GetSizingGroupBy(string urlId = null)
        {

          
            int departmentId = 70000;
            int colorId = 0;
            int styleId = 0;
            int materialId = 0;
            int heelHeightId = 0;
            string[] idstring;
            ICollection<SizingGroupDTO> qResults = null;


            if (urlId != null)
            {
                idstring = urlId.Split('-');
                if (idstring.Length > 0)
                {
                    int.TryParse(idstring[0],out departmentId);
                }
                if (idstring.Length > 2)
                {
                    int.TryParse(idstring[2], out colorId);
                }
                if (idstring.Length > 3)
                {
                    int.TryParse(idstring[3], out styleId);
                }
                if (idstring.Length > 4)
                {
                    int.TryParse(idstring[4], out materialId);
                }
                if (idstring.Length > 5)
                {
                    int.TryParse(idstring[5], out heelHeightId);
                }
            }

            await _context.LoadStoredProc("TF_Itemsgroup_Sizes_GetGroupTotal")
                .WithSqlParam("departmentId", departmentId)
                .WithSqlParam("lowerPrice", 0)
                .WithSqlParam("upperPrice", 0)
                .WithSqlParam("colorId", colorId)
                //.WithSqlParam("brandId", styleId)
                .WithSqlParam("styleId", styleId)
                .WithSqlParam("materialId", materialId)
                .WithSqlParam("heelHeightId", heelHeightId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    qResults = SetDestinationUrl(handler.ReadToList<SizingGroupDTO>(), departmentId, colorId, styleId, materialId, heelHeightId);
                });
            return Ok(qResults);
        }

        private ICollection<SizingGroupDTO> SetDestinationUrl(ICollection<SizingGroupDTO> MList, int departmentId, int colorId, int styleId,int materialId,int heelHeightId)
        {
            foreach (SizingGroupDTO qResult in MList)
            {
                qResult.destinationUrl = URLHelper.GetGroupingURLPath("https://localhost:44397", "category", departmentId, AttributeHelper.GetDepartmentName(_context, departmentId), (int)qResult.sizeCode, qResult.sizeDesc, colorId, AttributeHelper.GetColorName(_context, colorId), styleId, AttributeHelper.GetStyleName(_context, styleId),materialId,AttributeHelper.GetMaterialName(_context,materialId),heelHeightId,AttributeHelper.GetHeelHeight(_context,heelHeightId));
            }

            return MList;
        }


    }
}
