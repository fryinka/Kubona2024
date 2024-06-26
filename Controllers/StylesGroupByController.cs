using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using Kubona.Data.Helper;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylesGroupByController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public StylesGroupByController(BuyAWatchContext context)
        {
            _context = context;
        }




        [HttpGet("{urlId}")]
        public async Task<ActionResult<IEnumerable<StyleGroupDTO>>> GetStylesGroupBy(string urlId = null)
        {
            int? rgt = 0;
            int? lft = 0;
            int departmentId = 70000;
            int sizeId = 0;
            int colorId = 0;
            int materialId = 0;
            int heelHeightId = 0;
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
                if (idstring.Length > 4)
                {
                    int.TryParse(idstring[4], out materialId);
                }
                if(idstring.Length > 5)
                {
                    int.TryParse(idstring[5], out heelHeightId);
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
                (materialId == 0 || m.MaterialId == materialId)&&
                (heelHeightId == 0 || m.HeelHeight == heelHeightId))
                .Join(_context.TfItemsgroupSizes.Where(d => d.Quantity > 0 &&
                (sizeId == 0 || d.SizeCode == sizeId)), g => g.ItemGroupId, d => d.ItemGroupId,
                (g, d) => new
                {
                    ItemGroupId = g.ItemGroupId,
                    styleId = g.StyleId
                })
                .Join(_context.TfSubDepartments, o => o.styleId, m => m.SubDepartmentId, (o, m) =>
                new
                {
                    styleId = o.styleId,
                    styleDesc = m.SubDepartment,
                    itemGroupId = o.ItemGroupId
                }).GroupBy(m => new { m.styleId, m.styleDesc })
                .Select(c => new StyleGroupDTO
                {
                    styleId = c.Key.styleId,
                    styleDesc = c.Key.styleDesc,
                    totalcount = c.Select(s => s.itemGroupId).Distinct().Count()
                }
                )
                .OrderBy(c => c.styleDesc)
                .ToListAsync();

            foreach (StyleGroupDTO qResult in myGrp)
            {
                qResult.destinationUrl = URLHelper.GetGroupingURLPath("https://localhost:44397", "category", departmentId, AttributeHelper.GetDepartmentName(_context, departmentId), sizeId, AttributeHelper.GetSizeName(_context, sizeId), colorId, AttributeHelper.GetColorName(_context, colorId), (int)qResult.styleId, qResult.styleDesc, materialId, AttributeHelper.GetMaterialName(_context, materialId), heelHeightId, AttributeHelper.GetHeelHeight(_context, heelHeightId));
            }

            return myGrp;

        }
    }
}
