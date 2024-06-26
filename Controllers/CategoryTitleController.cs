using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using Kubona.Data.Helper;
using System.Web;
using System.Text;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryTitleController : ControllerBase
    {

        private readonly BuyAWatchContext _context;

        public CategoryTitleController(BuyAWatchContext context)
        {
            _context = context;
        }

        // GET: api/TfMenuLinks
        [HttpGet("{urlId}")]
        public async Task<ActionResult<CategoryTitleDTO>> GetCategoryTitle(string urlId = null)
        {

            int departmentId = 70000;
            int sizeId = 0;
            int colorId = 0;
            int styleId = 0;
            int materialId = 0;
            int heelHeightId = 0;
            string[] idstring;
            StringBuilder urlTitle = new StringBuilder();


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
                if (idstring.Length > 5)
                {
                    int.TryParse(idstring[5], out heelHeightId);
                }
            }

            if (colorId > 0)
            {
                urlTitle.Append(AttributeHelper.GetColorName(_context,colorId)).Append(' ');
            }
            if (sizeId > 0)
            {
                urlTitle.Append(AttributeHelper.GetSizeName(_context, sizeId)).Append(' ');
            }
            if (materialId > 0)
            {
                urlTitle.Append(AttributeHelper.GetMaterialName(_context, materialId)).Append(' ');
            }
            if (styleId > 0)
            {
                urlTitle.Append(AttributeHelper.GetStyleName(_context, styleId)).Append(' ');

            }
            if (heelHeightId > 0)
            {
                urlTitle.Append(AttributeHelper.GetHeelHeight(_context, heelHeightId)).Append(' ');
            }
            if (departmentId > 0)
            {
                urlTitle.Append(AttributeHelper.GetDepartmentName(_context, departmentId));
            }

            CategoryTitleDTO categoryTitle = new CategoryTitleDTO
            {
                categoryId = departmentId,
                categoryDesc = urlTitle.ToString(),
                urlId = urlId
            };

            return categoryTitle;

        
        }

    }
}
