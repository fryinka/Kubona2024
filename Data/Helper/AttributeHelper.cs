using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;

namespace Kubona.Data.Helper
{
    public static class AttributeHelper
    {

      
        public static string GetDepartmentName(BuyAWatchContext _context, int departmentId)
        {
           
            var aTempVar = _context.TfDepartments
                      .Where(m => m.DepartmentId == departmentId).FirstOrDefault();

                if (aTempVar == null)
                {
                    return null;
                }
                else
                {
                    return aTempVar.Description;
                }

          
        }

        public static string GetColorName(BuyAWatchContext _context, int colorId)
        {

            var aTempVar = _context.BwColors
                      .Where(m => m.ColorId == colorId).FirstOrDefault();

            if (aTempVar == null)
            {
                return null;
            }
            else
            {
                return aTempVar.ColorDesc;
            }


        }

        public static string GetStyleName(BuyAWatchContext _context, int styleId)
        {

            var aTempVar = _context.TfSubDepartments
                      .Where(m => m.SubDepartmentId == styleId).FirstOrDefault();

            if (aTempVar == null)
            {
                return null;
            }
            else
            {
                return aTempVar.SubDepartment;
            }


        }

        public static string GetMaterialName(BuyAWatchContext _context, int materialId)
        {
            var aTempVar = _context.BwMaterials.Where(x=>x.MaterialId == materialId).FirstOrDefault();
            if (aTempVar == null) { return null; } else { return aTempVar.MaterialName; }
        }
        public static string GetHeelHeight(BuyAWatchContext _context, int heelHeightId)
        {
            var aTempVar = _context.TfHeelHeights.Where(x => x.HeelHeightId == heelHeightId).FirstOrDefault();
            if (aTempVar == null) { return null; } else { return aTempVar.Desc; }
        }

        public static string GetSizeName(BuyAWatchContext _context, int sizeId)
        {
            string desc = null;
            if (sizeId > 0)
            {
             var size =  _context.TfSizes.Where(x => x.SizeCode == sizeId).FirstOrDefault();
             desc = size.SizeDesc;
              return desc;
            } else if (sizeId == 0)
            {
                return null;
            }
           else
            {
                return "Half Size";
            }
        }

        public static string ConvertToInternationalFormat(string phoneNumber)
        {
            // Remove any leading zeros and spaces
            phoneNumber = phoneNumber.TrimStart('0', ' ');

            // Check if the number starts with "234" 
            if (phoneNumber.StartsWith("234") && phoneNumber.Length == 13)
            {
                return phoneNumber; 
            }
            else if (phoneNumber.Length == 10)
            {
                return "234" + phoneNumber;
            }
            else
            {
                return phoneNumber;
            }
            
        }


    }
}
