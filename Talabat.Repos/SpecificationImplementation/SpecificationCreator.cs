using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Interfaces;

namespace Talabat.Repo.SpecificationImplementation
{
    public class SpecificationCreator<T> where T : BaseModel
    {
        public static IQueryable<T> CreateQuery(IQueryable<T> inputQuery, IBaseSpecification<T> spec)
        {
            var query = inputQuery;
            if (spec.Condition is not null)
                query = query.Where(spec.Condition);
            if (spec?.Includes?.Count > 0)
                foreach (var inc in spec.Includes)
                    query = query.Include(inc);


            return query;




        }
    }
}
