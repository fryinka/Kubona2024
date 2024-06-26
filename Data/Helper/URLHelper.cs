using System;
using System.Linq;
using System.Text;

namespace Kubona.Data.Helper
{
    public class URLHelper
    {
       
        public static string GetYouTubeString(string YouTubeId)
        {
            if (YouTubeId != null)
            {
                return string.Format("https://www.youtube.com/embed/{0}", YouTubeId);
               
            } else
            {
                return null;
            }
        }
        public static string ToCleanUrl(string urlToTidy)
        {
            if (urlToTidy != null)
            {
                return urlToTidy.Trim().Replace("&amp;", "n").Replace("&#39;", "").Replace("+", "n").Replace("  ", " ").Replace(" - ", " ").Replace("+", "").Replace(" ", "-").Replace(",", "").Replace("...", "").Replace(" & ", " and ").Trim().Replace("amp;", "").Replace("&", "").Replace("'", "").Replace("/", "").Replace(" ", "-").Replace(".", "").Replace(":", "").Replace("%", "-Per-");
            }
            else
            {
                return null;
            }
        }

        public static string CleanExternalUrl(string urlToClean)
        {
            if (!string.IsNullOrEmpty(urlToClean))
            {
                return urlToClean.ToLower().Trim().Replace("https://", "").Replace("http://", "").Replace("www/", "");
            }
            else
            {
                return null;
            }
        }

        public static string[] SplitUrl(string urlToSplit, char delimiter)
        {
            return urlToSplit.Split(delimiter);
        }


        public static string GetMainURLPath(string domain, string route, string title, string id)
        {
            StringBuilder urlPath = new StringBuilder();
            //return urlPath.Append(domain).Append('/').Append(route).Append('/').Append(id).Append('-').Append(ToCleanUrl(title)).ToString();
            return urlPath.Append(id).Append('-').Append(ToCleanUrl(title)).ToString();


                }

        public static string GetGroupingURLPath(string domain, string route, int departmentId, string departmentName, int sizeId, string sizeDesc, int colorId, string colorDesc, int styleId, string styleDesc,int materialId,string materialDesc,int heelHeightId,string heelHeightDesc)
        {
            string groupId = GetGroupingID(departmentId.ToString(), sizeId.ToString(), colorId.ToString(), styleId.ToString(),materialId.ToString(),heelHeightId.ToString());
            string groupTitle = GetGroupingTitle(departmentName, sizeDesc, colorDesc, styleDesc,materialDesc,heelHeightDesc);
            return GetMainURLPath(domain, route, groupTitle, groupId);
        }


        private static string GetGroupingID(string departmentId, string sizeId, string colorId, string styleId,string materialId, string heelHeightId)
        {
            StringBuilder urlID = new StringBuilder();
            return urlID.Append(departmentId).Append('-').Append(sizeId).Append('-').Append(colorId).Append('-').Append(styleId).Append('-').Append(materialId).Append('-').Append(heelHeightId).ToString();
        }

        private static string GetGroupingTitle(string departmentName, string SizeDesc, string ColorDesc, string StyleDesc, string materialDesc, string heelHeightDesc)
        {
            StringBuilder urlTitle = new StringBuilder();
            if (ColorDesc != null)
            {
                urlTitle.Append(ColorDesc).Append('-');
            }
            if (SizeDesc != null)
            {
                urlTitle.Append(SizeDesc).Append('-');
            }
            if (StyleDesc != null)
            {
                urlTitle.Append(StyleDesc).Append('-');

            }
            if (materialDesc != null)
            {
                urlTitle.Append(materialDesc).Append('-');
            }
            if (heelHeightDesc != null)
            {
                urlTitle.Append(heelHeightDesc).Append('-');
            }
            urlTitle.Append(departmentName);
            return urlTitle.ToString();
        }

    }
}

