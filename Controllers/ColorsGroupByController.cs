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
    public class ColorsGroupByController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public ColorsGroupByController(BuyAWatchContext context)
        {
            _context = context;
        }

       


        [HttpGet("{urlId}")]
        public async Task<ActionResult<IEnumerable<ColourGroupDTO>>> GetColorsGroupBy(string urlId = null)
        {
            int? rgt = 0;
            int? lft = 0;
            int departmentId = 70000;
            int sizeId = 0;
            int styleId = 0;
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
                (styleId == 0 || m.StyleId == styleId) &&
                (materialId == 0 || m.MaterialId == materialId) &&
                (heelHeightId == 0 || m.HeelHeight == heelHeightId))
                .Join(_context.TfItemsgroupSizes.Where(d => d.Quantity > 0 &&
                (sizeId == 0 || d.SizeCode == sizeId)), g => g.ItemGroupId, d => d.ItemGroupId,
                (g, d) => new
                {
                    ItemGroupId = g.ItemGroupId,
                    ColorId = g.ColorId
                })
                .Join(_context.BwColors, o => o.ColorId, m => m.ColorId, (o, m) =>
                new
                {
                    colorId = o.ColorId,
                    colorDesc = m.ColorDesc,
                    itemGroupId = o.ItemGroupId

                }).GroupBy(m => new { m.colorId, m.colorDesc })
                .Select(c => new ColourGroupDTO
                {
                    colorId  = c.Key.colorId,
                    colorDesc = c.Key.colorDesc,
                    totalcount = c.Select(s => s.itemGroupId).Distinct().Count()
                }
                )
                .OrderBy(c => c.colorDesc)
                .ToListAsync();

            foreach (ColourGroupDTO qResult in myGrp)
            {
                qResult.destinationUrl = URLHelper.GetGroupingURLPath("https://localhost:44397", "category", departmentId, AttributeHelper.GetDepartmentName(_context, departmentId), sizeId, AttributeHelper.GetSizeName(_context,sizeId), (int)qResult.colorId, qResult.colorDesc, styleId, AttributeHelper.GetStyleName(_context, styleId),materialId,AttributeHelper.GetMaterialName(_context,materialId),heelHeightId,AttributeHelper.GetHeelHeight(_context,heelHeightId));
            }

            return myGrp;

        }


    }
}
