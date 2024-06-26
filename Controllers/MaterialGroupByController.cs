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
    public class MaterialGroupByController : ControllerBase
    {
        private readonly BuyAWatchContext _context;
        public MaterialGroupByController(BuyAWatchContext context)
        {
            _context = context;
        }       
        [HttpGet("{urlId}")]
        public async Task<ActionResult<IEnumerable<MaterialGroupDTO>>> GetMaterialsGroupBy(string urlId = null)
        {
            int? rgt = 0;
            int? lft = 0;
            int departmentId = 70000;
            int sizeId = 0;
            int colorId = 0;
            int styleId = 0;
            int heelHeightId = 0;
            int lowerPrice = 0;
            int upperPrice = 0;
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
                if (idstring.Length > 5)
                {
                    int.TryParse(idstring[5], out heelHeightId);
                }
                if (idstring.Length > 6)
                {
                    int.TryParse(idstring[6], out lowerPrice);
                }
                if (idstring.Length > 7)
                {
                    int.TryParse(idstring[7], out upperPrice);
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
                (heelHeightId == 0 || m.HeelHeight == heelHeightId) &&
                (lowerPrice == 0 || m.Internetprice >= lowerPrice) &&
                (upperPrice == 0 || m.Internetprice <= upperPrice))
                .Join(_context.TfItemsgroupSizes.Where(d => d.Quantity > 0 &&
                (sizeId == 0 || d.SizeCode == sizeId)), g => g.ItemGroupId, d => d.ItemGroupId,
                (g, d) => new
                {
                    ItemGroupId = g.ItemGroupId,
                    materialId = g.MaterialId
                })
                .Join(_context.BwMaterials, o => o.materialId, m => m.MaterialId, (o, m) =>
                new
                {
                    materialId = o.materialId,
                    materialDesc = m.MaterialName,
                    itemGroupId = o.ItemGroupId
                }).GroupBy(m => new { m.materialId, m.materialDesc })
                .Select(c => new MaterialGroupDTO
                {
                    materialId = c.Key.materialId,
                    materialDesc = c.Key.materialDesc,
                    totalcount = c.Select(s => s.itemGroupId).Distinct().Count()
                }
                )
                .OrderBy(c => c.materialDesc)
                .ToListAsync();

            foreach (MaterialGroupDTO qResult in myGrp)
            {
                qResult.destinationUrl = URLHelper.GetGroupingURLPath("https://localhost:44397", "category", departmentId, AttributeHelper.GetDepartmentName(_context, departmentId), sizeId, AttributeHelper.GetSizeName(_context, sizeId), colorId, AttributeHelper.GetColorName(_context, colorId), styleId, AttributeHelper.GetStyleName(_context,styleId), (int)qResult.materialId, qResult.materialDesc, heelHeightId, AttributeHelper.GetHeelHeight(_context, heelHeightId));
            }

            return myGrp;

        }
    }
}
