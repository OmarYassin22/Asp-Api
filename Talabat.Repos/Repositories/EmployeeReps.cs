using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models.Company;
using Talabat.Repo.Data.Contexts;
using Talabat.Repos.Data.Contexts;
using Talabat.Repos.Repositories;

namespace Talabat.Repo.Repositories
{
    public class EmployeeReps:GenericRepository<Employee>
    { 
        private readonly CompanyDbContext companycontext;

 
        public EmployeeReps(StoreDbContext context, CompanyDbContext Companycontext) : base(context)
        {
            companycontext = Companycontext;
        }

        public async Task<int> AddAsync(Employee employee)
        {
            companycontext.Add(employee);
            var res = await companycontext.SaveChangesAsync();
            return res;   


        }
    }
}
