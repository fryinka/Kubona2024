using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubona.Data.Models
{
    public class kubonaEnums
    {
        public enum orderLoggerStatus
        {
            pending = 1,
            identified = 2,
            checkout = 5,
            new_checkout = 7
        }
    }
}
