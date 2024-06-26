using Kubona.Data.Helper;
using Kubona.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeelHeightGroupByController : ControllerBase
    {
        private readonly BuyAWatchContext _context;
        public HeelHeightGroupByController(BuyAWatchContext context)
        {
            _context = context;
        }
        [HttpGet("{urlId}")]
        public async Task<ActionResult<IEnumerable<HeelHeightGroupDTO>>> GetHeelsGroupBy(string urlId = null)
        {
            int? rgt = 0;
            int? lft = 0;
            int departmentId = 70000;
            int sizeId = 0;
            int colorId = 0;
            int styleId = 0;
            int materialId = 0;
            string[] idstring;

            if (urlId != null)
            {
                idstring = urlId.Split('-');
                if (idstring.Length > 0)
                {
                    int.TryParse(idstring[0], out departmentId);
                }
                if (idstring.Length > 1)
                {
                    int.TryParse(idstring[1], out sizeId);
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
            }


            if (departmentId > 0)
            {
                var tfDepartment = await _context.TfDepartments.FindAsync(departmentId);
                if (tfDepartment != null)
                {
                    rgt = tfDepartment.Rgt;
                    lft = tfDepartment.Lft;
                };

            };

            var myGrp = await _context.TfItemsGroups
                 .Where(m => m.NumAvailable > 0 &&
                (lft == 0 || m.TfDepartment.Lft >= lft) &&
                (rgt == 0 || m.TfDepartment.Rgt <= rgt) &&
                (colorId == 0 || m.ColorId == colorId) &&
                (styleId == 0 || m.StyleId == styleId) &&
                (materialId == 0 || m.MaterialId == materialId))
                .Join(_context.TfItemsgroupSizes.Where(d => d.Quantity > 0 &&
                (sizeId == 0 || d.SizeCode == sizeId)), g => g.ItemGroupId, d => d.ItemGroupId,
                (g, d) => new
                {
                    ItemGroupId = g.ItemGroupId,
                    heelHeightId = g.HeelHeight
                })
                .Join(_context.TfHeelHeights, o => o.heelHeightId, m => m.HeelHeightId, (o, m) =>
                new
                {
                    heelHeightId = o.heelHeightId,
                    heelHeightDesc = m.Desc,
                    itemGroupId = o.ItemGroupId
                }).GroupBy(m => new { m.heelHeightId, m.heelHeightDesc })
                .Select(c => new HeelHeightGroupDTO
                {
                    heelHeightId = c.Key.heelHeightId,
                    heelHeightDesc = c.Key.heelHeightDesc,
                    totalcount = c.Select(s => s.itemGroupId).Distinct().Count()
                }
                )
                .OrderBy(c => c.heelHeightDesc)
                .ToListAsync();

            foreach (HeelHeightGroupDTO qResult in myGrp)
            {
                qResult.destinationUrl = URLHelper.GetGroupingURLPath("https://localhost:44397", "category", departmentId, AttributeHelper.GetDepartmentName(_context, departmentId), sizeId, AttributeHelper.GetSizeName(_context, sizeId), colorId, AttributeHelper.GetColorName(_context, colorId), styleId, AttributeHelper.GetStyleName(_context,styleId), materialId, AttributeHelper.GetMaterialName(_context, materialId), (int)qResult.heelHeightId, qResult.heelHeightDesc);
            }

            return myGrp;

        }
    }
}
