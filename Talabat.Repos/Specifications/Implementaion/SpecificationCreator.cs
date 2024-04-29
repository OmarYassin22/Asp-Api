using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Interfaces;

namespace Talabat.Repo.Specifications.SpecificationImplementation
{
    public class SpecificationCreator<T> where T : BaseModel
    {
        public static IQueryable<T> CreateQuery(IQueryable<T> inputQuery, IBaseSpecification<T> spec)
        {
            var query = inputQuery;
            if (spec.Condition is not null)
                query = query.Where(spec.Condition);
            if (spec?.Includes?.Count > 0)
                query = spec?.Includes?.Aggregate(query, (currentQuery, NextIncludes) => currentQuery.Include(NextIncludes));

            if (spec?.Order is not null)
            {
                query = query.OrderBy(spec.Order);

            }
            else
            {
                query = query.OrderBy(spec.OrderDesc);
            }
            return query;




        }
    }
}
