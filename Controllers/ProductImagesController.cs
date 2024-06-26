using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public ProductImagesController(BuyAWatchContext context)
        {
            _context = context;
        }

       


        [HttpGet]
        public async Task<ActionResult<IEnumerable<NgImageSliderDTO>>> GetProductImages(string Id)
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

            List<NgImageSliderDTO> ngImageSliders = new List<NgImageSliderDTO>();
            int counter = 2;

            var firstImage = await _context.TfItemsGroups
                            .Where(m => m.ItemGroupId == productId)
                            .FirstOrDefaultAsync();
            if (firstImage != null)
            {


                NgImageSliderDTO firstNgImage = new NgImageSliderDTO
                {
                    image = firstImage.HighResolutionUrl,
                    thumbImage = firstImage.HighResolutionUrl,
                    alt = firstImage.Title,
                    title = firstImage.Title,
                    order = 1
                };
                ngImageSliders.Add(firstNgImage);


                var prodImages = await _context.TfItemsImages
                    .Where(m => m.ProductId == productId)
                    .OrderBy(c => c.ProductImageId)
                    .ToListAsync();
                if (prodImages != null)
                {
                    foreach (TfItemsImage qResult in prodImages)
                    {
                        NgImageSliderDTO currentImage = new NgImageSliderDTO();
                        currentImage.image = qResult.SquareImageUrl;
                        currentImage.thumbImage = qResult.SquareImageUrl;
                        currentImage.alt = firstImage.Title;
                        currentImage.title = firstImage.Title;
                        currentImage.order = counter;
                        ngImageSliders.Add(currentImage);
                        counter = counter + 1;
                    }
                }
            }
            return ngImageSliders;

        }


    }
}
