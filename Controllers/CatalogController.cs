using Kubona.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using Kubona.Data.Helper;
using Kubona.Data.Snickler;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly BuyAWatchContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly int _expiredProductType;

        public CatalogController(BuyAWatchContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _expiredProductType = 5;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogDTO>> GetCatalogs(string id)
        {
            IEnumerable<PriceCheckDatum> qResults = null;
            CatalogDTO dTO = new CatalogDTO();

            await _context.LoadStoredProc("TF_Itemsgroup_GetCatalog")
              .WithSqlParam("pageSize", 0)
              .ExecuteStoredProcAsync((handler) =>
              {
                  qResults = handler.ReadToList<PriceCheckDatum>();
                  dTO.wwwRoot = CreateXMLString(qResults);
                  dTO.itemCount = qResults.Count();

              });

            return dTO;
        }


        private CatalogDTO WriteSiteMap(string xmlFiletoWrite)
        {
            CatalogDTO cDTo = new CatalogDTO();
            var path = Path.Combine(_env.ContentRootPath, "\\External");

            string filename = string.Format("{0}\\External\\KubonaSiteMap.xml", _env.WebRootPath);
            cDTo.wwwRoot = filename;
            try
            {
                // Create a FileStream with mode CreateNew  
                FileStream stream = new FileStream(filename, FileMode.Create);
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(xmlFiletoWrite);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
                cDTo.errorMessage = exp.Message;
            }
            return cDTo;

        }

        private CatalogDTO WriteCatalogfile(string xmlFiletoWrite)
        {
            CatalogDTO cDTo = new CatalogDTO();
            var path = Path.Combine(_env.ContentRootPath, "\\External");

            string filename = string.Format("{0}\\External\\NoHandbagShop.xml", _env.WebRootPath);
            cDTo.wwwRoot = filename;
            try
            {
                // Create a FileStream with mode CreateNew  
                FileStream stream = new FileStream(filename, FileMode.Create);
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(xmlFiletoWrite);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
                cDTo.errorMessage = exp.Message;
            }
            return cDTo;

        }



        private CatalogDTO WriteXMLfile(string xmlFiletoWrite)
        {
            CatalogDTO cDTo = new CatalogDTO();
            var path = Path.Combine(_env.ContentRootPath, "\\External");

            string filename = string.Format("{0}\\External\\NoHandbagShop.xml", _env.WebRootPath);
            cDTo.wwwRoot = filename;
            try
            {
                // Create a FileStream with mode CreateNew  
                FileStream stream = new FileStream(filename, FileMode.Create);
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(xmlFiletoWrite);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
                cDTo.errorMessage = exp.Message;
            }
            return cDTo;

        }

        private string CreateXMLString(IEnumerable<PriceCheckDatum> mI)
        {
            StringBuilder pCI = new StringBuilder();
            StringBuilder siteMap = new StringBuilder();


            pCI.AppendLine("<?xml version=\"1.0\" encoding='UTF8'?>");
            pCI.AppendLine("<rss version=\"2.0\" xmlns:g=\"http://base.google.com/ns/1.0\" xmlns:c=\"http://base.google.com/cns/1.0\">");
            pCI.AppendLine("<channel>");
            pCI.AppendLine("<title>kubona.ng - Online Store</title>");
            pCI.AppendLine("<link>http://www.kubona.ng</link>");
            pCI.AppendLine("<description>Product Feed for Kubona.ng</description>");

            siteMap.AppendLine("<?xml version=\"1.0\" encoding='UTF8'?>");
            siteMap.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:image=\"http://www.google.com/schemas/sitemap-image/1.1\" xmlns:video=\"http://www.google.com/schemas/sitemap-video/1.1\">");


            foreach (PriceCheckDatum cI in mI)
            {
                if (!string.IsNullOrEmpty(cI.ImageUrl))
                {
                    if (cI.ImageUrl.Length > 10)
                    {
                        string description = null;
                        if (!string.IsNullOrEmpty(cI.SizeDesc))
                        {
                            description = String.Format("{0} sizes available", cI.SizeDesc.TrimStart(';'));
                        }
                        else
                        {
                            description = String.Format("{0} - {1} - {2}", cI.Trackingid, cI.Price, cI.Title);
                        }
                        pCI.AppendLine("<item>");
                        pCI.AppendFormat("<g:title><![CDATA[{0}]]></g:title>", String.Format("{0}", cI.Title));
                        pCI.AppendLine("");
                        pCI.AppendFormat("<g:link><![CDATA[http://www.kubona.ng/product/{0}-{1}]]></g:link>", cI.ShopSku, URLHelper.ToCleanUrl(cI.Title).ToLower());
                        pCI.AppendLine("");
                        pCI.AppendFormat("<g:description><![CDATA[{0}]]></g:description>", description);
                        pCI.AppendLine("");
                        pCI.AppendFormat("<g:id>{0}</g:id>", cI.ShopSku);
                        pCI.AppendLine("");
                        pCI.AppendFormat("<g:item_group_id>{0}</g:item_group_id>", cI.ShopSku);
                        pCI.AppendLine("");
                        pCI.AppendLine("<g:condition>new</g:condition>");
                        pCI.AppendLine("<g:availability>in stock</g:availability>");
                        pCI.AppendLine("");
                        pCI.AppendFormat("<g:price>{0}</g:price>", cI.Price);
                        pCI.AppendLine("");
                        pCI.AppendLine("<g:gtin></g:gtin>");
                        pCI.AppendLine("<g:adult>no</g:adult>");

                        if (cI.SalePrice > 0)
                        {
                            pCI.AppendFormat("<g:sale_price>{0}</g:sale_price>", cI.SalePrice);
                            pCI.AppendLine("");
                            pCI.AppendLine("<g:custom_label_0>CLEARANCE</g:custom_label_0>");
                        }
                        else
                        {
                            pCI.AppendFormat("<g:sale_price>{0}</g:sale_price>", cI.Price);
                            pCI.AppendLine("");
                            pCI.AppendLine("<g:custom_label_0>ORIGINAL</g:custom_label_0>");
                        }

                        if (cI.ColorId > 0)
                        {
                            pCI.AppendFormat("<g:custom_label_1>{0}</g:custom_label_1>", cI.ColorId);
                            pCI.AppendLine("");
                        }

                        if (cI.ProductType == _expiredProductType)
                        {
                            pCI.AppendFormat("<g:expiration_date>{0}</g:expiration_date>", DateTime.UtcNow.AddDays(-2).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"));
                            pCI.AppendLine("");
                        }

                        if (!string.IsNullOrEmpty(cI.Manufacturer))
                        {
                            pCI.AppendFormat("<g:brand><![CDATA[{0}]]></g:brand>", cI.Manufacturer);
                            pCI.AppendLine("");
                        }
                        else
                        {
                            pCI.AppendLine("<g:brand></g:brand>");
                        }

                        if (!string.IsNullOrEmpty(cI.ThemeName))
                        {
                            pCI.AppendFormat("<g:custom_label_2><![CDATA[{0}]]></g:custom_label_2>", cI.ThemeName);
                            pCI.AppendLine("");
                        }

                        pCI.AppendFormat("<g:image_link>{0}</g:image_link>", cI.ImageUrl);
                        pCI.AppendLine("");

                        if (!string.IsNullOrEmpty(cI.Additionalimages))
                        {
                            pCI.AppendFormat("<g:additional_image_link>{0}</g:additional_image_link>", cI.Additionalimages.Trim(','));
                        }
                        else
                        {
                            pCI.AppendFormat("<g:additional_image_link>{0}</g:additional_image_link>", cI.ImageUrl);
                        }

                        pCI.AppendLine("");

                        if ((cI.DepartmentId > 70600) && (cI.DepartmentId < 70700))
                        {
                            pCI.AppendFormat("<g:custom_label_3>Men_{0}</g:custom_label_3>", cI.AvailableSizeCount);
                        }
                        else
                        {
                            pCI.AppendFormat("<g:custom_label_3>Women_{0}</g:custom_label_3>", cI.AvailableSizeCount);
                        }

                        pCI.AppendLine("");

                        pCI.AppendFormat("<g:google_product_category><![CDATA[{0}]]></g:google_product_category>", cI.Googleid);
                        pCI.AppendLine("");
                        pCI.AppendFormat("<g:product_type><![CDATA[{0}]]></g:product_type>", cI.Category);
                        pCI.AppendLine("");


                        pCI.AppendLine("</item>");

                        siteMap.AppendLine("<url>");
                        siteMap.AppendFormat("<loc><![CDATA[http://www.kubona.ng/product/{0}-{1}]]></loc>", cI.ShopSku, URLHelper.ToCleanUrl(cI.Title).ToLower());
                        siteMap.AppendLine("");
                        siteMap.AppendLine("<image:image>");
                        siteMap.AppendFormat("<image:loc>{0}</image:loc>", cI.ImageUrl);
                        siteMap.AppendLine("");
                        siteMap.AppendFormat("<image:caption><![CDATA[{0}]]></image:caption>", cI.Title);
                        siteMap.AppendLine("");
                        siteMap.AppendLine("</image:image>");
                        siteMap.AppendLine("</url>");
                    }
                }
            }
            pCI.AppendLine("</channel>");
            pCI.AppendLine("</rss>");
            siteMap.AppendLine("</urlset>");

            WriteSiteMap(siteMap.ToString());
            return WriteCatalogfile(pCI.ToString()).wwwRoot;



        }


    }
}
