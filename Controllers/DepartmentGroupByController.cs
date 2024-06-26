using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kubona.Data.Models;
using Kubona.Data.Snickler;
using Kubona.Data.Helper;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentGroupByController : ControllerBase
    {
        private readonly BuyAWatchContext _context;

        public DepartmentGroupByController(BuyAWatchContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TfDepartmentGroupByDTO>>> GetDepartmentGroupBy(string urlId = null)
        {
            //return await _context.TfDepartments.ToListAsync();
            ICollection<TfDepartmentGroupByDTO> qResults = null;
            DateTime currentDate = DateTime.Now;
            int departmentId = 70000;
            string[] idstring;

            if (urlId != null)
            {
                idstring = urlId.Split('-');
                if (idstring.Length > 0)
                {
                    int.TryParse(idstring[0], out departmentId);
                }
            }

                await _context.LoadStoredProc("TF_Department_GetChildrenByDepartment")
                .WithSqlParam("departmentId", departmentId)
                .WithSqlParam("today",currentDate)
                .ExecuteStoredProcAsync((handler) =>
                {
                    qResults = SetDestinationUrl(handler.ReadToList<TfDepartmentGroupByDTO>());
                   
                });
            return Ok(qResults);
        }

      private ICollection<TfDepartmentGroupByDTO> SetDestinationUrl(ICollection<TfDepartmentGroupByDTO> MList)
      {
            foreach(TfDepartmentGroupByDTO qResult in MList)
            {
                qResult.destinationUrl = URLHelper.GetMainURLPath("https://localhost:44397", "category", qResult.description, qResult.departmentId.ToString());
            }

            return MList;
      }

    }
}
