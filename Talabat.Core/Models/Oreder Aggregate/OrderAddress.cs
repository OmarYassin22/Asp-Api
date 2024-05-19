using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Models.Oreder_Aggregate
{
    public class OrderAddress
    {
        public required string FirstName { get; set; }
        public  string LastName { get; set; } = null!;
        public  string Street { get; set; } = null!;
        public  string City { get; set; } = null!;
        public  string country { get; set; } = null!;

    }
}
