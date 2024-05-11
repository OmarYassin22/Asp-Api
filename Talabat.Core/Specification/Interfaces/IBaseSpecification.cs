using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;

namespace Talabat.Access.Specifications.Product.Interfaces
{
    public interface IBaseSpecification<T> where T : BaseModel
    {
        public Expression<Func<T, bool>> Condition { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
        public Expression<Func<T,object>> Order {  get; set; }
        public Expression<Func<T,object>> OrderDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagination { get; set; }

    }
}
