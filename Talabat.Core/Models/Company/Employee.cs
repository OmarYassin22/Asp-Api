using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Access.Models.Company
{
    //[Table("Employee", Schema = "Company")]

    public class Employee:BaseModel
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
