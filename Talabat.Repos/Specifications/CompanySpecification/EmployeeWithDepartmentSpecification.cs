using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models.Company;
using Talabat.Access.Specifications.Product.Classes;

namespace Talabat.Access.Specifications.CompanySpecification
{
    public class EmployeeWithDepartmentSpecification : BaseSpecification<Employee>
    {
        public EmployeeWithDepartmentSpecification() : base()
        {
            Includes.Add(e => e.Department);
        }
        public EmployeeWithDepartmentSpecification(int id):base(e=>e.Id==id)
        {
            Includes.Add(e => e.Department);

        }
    }
}
