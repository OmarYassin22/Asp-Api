    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;

namespace Talabat.Core.Models.Oreder_Aggregate
{
    public class DeliveryMethod:BaseModel
    {
        public string ShortName { get; set; }

        public string Description { get; set; } = null!;
        public decimal Cost { get; set; }

        public string DeliveryTime { get; set; } = null!;
            


    }
}
