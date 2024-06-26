using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class CatalogDTO
    {
        public CatalogDTO() { }
        public string wwwRoot { set; get; }
        public int itemCount { set; get; }
        public string errorMessage { set; get; }
        
    }
}
