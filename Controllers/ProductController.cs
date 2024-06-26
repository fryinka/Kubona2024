using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using Kubona.Data.Helper;
using System.Text;
using Microsoft.Extensions.Options;


namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BuyAWatchContext _context;
        private readonly IOptions<WebsiteSettings> _appSettings;

        public ProductController(BuyAWatchContext context, IOptions<WebsiteSettings> options)
        {
            _context = context;
            _appSettings = options;
        }

        // GET: api/TfItemsGroups
        [HttpGet("Products/{urlId}")]
        public async Task<ActionResult<IEnumerable<TfItemsGroupDTO>>> GetProducts(string urlId = null, decimal? lowerPrice = 0, decimal? upperPrice = 0, int? sortId = 0, int pageIndex =0, int pageSize =30)
        {
            int? rgt = 0;
            int? lft = 0;
            int departmentId = 70000;
            int sizeId = 0;
            int colorId = 0;
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

            if (departmentId > 0)
            {
                var tfDepartment = await _context.TfDepartments.FindAsync(departmentId);
                if (tfDepartment != null)
                {
                    rgt = tfDepartment.Rgt;
                    lft = tfDepartment.Lft;
                };

            };

            var source = await _context.TfItemsGroups
                .Select(c => new TfItemsGroupDTO()
                {
                    Title = c.Title,
                    departmentId = c.DepartmentId,
                    numAvailable = c.NumAvailable,
                    itemGroupId = c.ItemGroupId,
                    colorDesc = c.BwColor.ColorDesc,
                    styleDesc = c.BwBrand.BrandName,
                    sizeDesc = _context.TF_ItemsGroup_GetAvailableSizes(c.ItemGroupId).Trim(','),
                    departmentName = c.TfDepartment.Description,
                    lft = c.TfDepartment.Lft,
                    rgt = c.TfDepartment.Rgt,
                    colorId = c.ColorId,
                    brandId = c.BrandId,
                    styleId=c.StyleId,
                    internetPrice = c.Internetprice,
                    storePrice = c.Storeprice,
                    numOfViews = c.NumOfViews,
                    image1Url = c.HighResolutionUrl,
                    addedDate = c.AddedDate,
                    destinationUrl = URLHelper.GetMainURLPath("https://localhost:44397", "category", c.Title, c.ItemGroupId.ToString()),
                    positionId = c.PositionId,
                    similarId=c.SimilarId,
                    heelHeightId=c.HeelHeight,
                    materialId= c.MaterialId
                })
                .Where(x => x.numAvailable > 0 &&
                (colorId == 0 || x.colorId == colorId) &&
                (styleId == 0 || x.styleId == styleId) &&
                (heelHeightId == 0 || x.heelHeightId == heelHeightId) &&
                (materialId == 0 || x.materialId == materialId) &&
                (lft == 0 || x.lft >= lft) &&
                (rgt == 0 || x.rgt <= rgt) &&
                (lowerPrice == 0 || x.internetPrice >= lowerPrice) &&
                (upperPrice == 0 || x.internetPrice <= upperPrice) &&
                (sizeId == 0 || _context.TF_ItemsGroup_IsSizeAvailable(x.itemGroupId, sizeId) == true)
                )
                .ToListAsync();

            if (sortId == 0 )
            {
                source = source.OrderBy(x => x.positionId)
                   .Skip(pageIndex * pageSize)
                  .Take(pageSize).ToList();
            }
            else
                if (sortId == 1)
            {
                source = source.OrderBy(x => x.addedDate)
                 .Skip(pageIndex * pageSize)
                .Take(pageSize).ToList();
            }
            else
            if (sortId == 2)
            {
                source = source.OrderByDescending(x => x.internetPrice)
                 .Skip(pageIndex * pageSize)
                .Take(pageSize).ToList();
            }
            else
            if (sortId == 3)
            {
                source = source.OrderBy(x => x.internetPrice)
                 .Skip(pageIndex * pageSize)
                .Take(pageSize).ToList();
            }
            else
            if (sortId == 4)
            {
                source = source.OrderBy(x => Guid.NewGuid())
                 .Skip(pageIndex * pageSize)
                .Take(pageSize).ToList();
            }
            else
            if (sortId == 5)
            {
                source = source.OrderBy(x => x.Title)
                 .Skip(pageIndex * pageSize)
                .Take(pageSize).ToList();
            }
            else
            if (sortId == 6)
            {
                source = source.OrderByDescending(x => x.Title)
                 .Skip(pageIndex * pageSize)
                .Take(pageSize).ToList();
            }
            else
            if (sortId == 7)
            {
                source = source.OrderByDescending(x => x.addedDate)
                 .Skip(pageIndex * pageSize)
                .Take(pageSize).ToList();
            }
            else
            {
                source = source.OrderBy(x => x.positionId)
                 .Skip(pageIndex * pageSize)
                .Take(pageSize).ToList();
            }

            return source;
        }

       
        // GET: api/TfItemsGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TfItemsGroupByIdDTO>> GetProduct(string id)
        {

            string[] idstring;
            int productId = 0;
        
            if (id != null)
            {
                idstring = id.Split('-');
                if (idstring.Length > 0)
                {
                    int.TryParse(idstring[0], out productId);
                }
            }

            var tfItemsGroup = await _context.TfItemsGroups
                .Select(c => new TfItemsGroupByIdDTO()
                {
                    Title = c.Title,
                    departmentId = c.DepartmentId,
                    numAvailable = c.NumAvailable,
                    itemGroupId = c.ItemGroupId,
                    colorDesc = c.BwColor.ColorDesc,
                    styleDesc = c.BwBrand.BrandName,
                    sizeDesc = _context.TF_ItemsGroup_GetAvailableSizes(c.ItemGroupId),
                    departmentName = c.TfDepartment.Description,
                    lft = c.TfDepartment.Lft,
                    rgt = c.TfDepartment.Rgt,
                    colorId = c.ColorId,
                    trackingId = c.TrackingId,
                    brandId = c.BrandId,
                    internetPrice = c.Internetprice,
                    storePrice = c.Storeprice,
                    numOfViews = c.NumOfViews,
                    similarId = c.SimilarId,
                    description = c.TfSubDepartment.SubDepartment,
                    youTubeId = URLHelper.GetYouTubeString(c.YouTubeId),
                    materialId = c.MaterialId,
                    heelHeightId = c.HeelHeight,
                    heelHeight = c.TfHeelHeight.Desc,
                    destinationUrl = URLHelper.GetMainURLPath("https://localhost:44397", "category", c.Title, c.ItemGroupId.ToString()),
                    
                })
                .Where(x => x.itemGroupId == productId).FirstOrDefaultAsync();
            if (tfItemsGroup == null)
            {
                return NotFound();
            }

            return tfItemsGroup;
        }

        [HttpGet("Sizes/{id}")]
        public async Task<ActionResult<IEnumerable<ItemsizesDTO>>> getSizes(string Id)
        {
            string[] idstring;
            int productId = 0;

            if (Id != null)
            {
                idstring = Id.Split('-');
                if (idstring.Length > 0)
                {
                    int.TryParse(idstring[0], out productId);
                }
            }

            List<ItemsizesDTO> a = (from d in _context.TfItemsgroupSizes
                     from b in _context.TfSizes
                     where d.SizeCode == b.SizeCode && d.ItemGroupId==productId
                     select new ItemsizesDTO()
                     {
                         itemGroupSizeId = d.ItemGroupSizeId,
                         itemGroupId = d.ItemGroupId,
                         sizeDesc = b.SizeDesc,
                         trackingId = d.TrackingId,
                         quantity = d.Quantity,
                         sizeCode = d.SizeCode
                     }).OrderBy(m => m.sizeCode).ToList();
            return a;
        }



        [HttpGet("ChangeHeel/{productIds}/{heelHeight}")]
        public async Task<int> insertItemsGroupDescriptionLog(string productIds, int heelHeight)

        {
            if (productIds != null)
            {
                string[] IDs = productIds.Split(",");
                int[] tempArr = Array.ConvertAll(IDs, s => int.Parse(s));
                var tempProd = await _context.TfItemsGroups.Where(f => tempArr.Contains(f.ItemGroupId)).ToListAsync();
                tempProd.ForEach(a => a.HeelHeight = heelHeight);
                _context.SaveChanges();
                return tempProd.Count;
            }
            return 0;
        }

        [HttpGet("GetHeels")]
        public async Task<ActionResult<IEnumerable<TfHeelHeight>>> GetHeels()
        {
            return await _context.TfHeelHeights.OrderBy(x=>x.Desc).ToListAsync();
        }
        private bool TfItemsGroupExists(int id)
        {
            return _context.TfItemsGroups.Any(e => e.ItemGroupId == id);
        }
    }
}
