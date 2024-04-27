using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Access.Models.Company
{
    public class Employee:BaseModel
    {
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
