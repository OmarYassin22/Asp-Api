using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Interfaces;

namespace Talabat.Access.Specifications.Product.Classes
{
    public class BaseSpecification<T> : IBaseSpecification<T> where T : BaseModel
    {
        public Expression<Func<T, bool>> Condition { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Order { get; set; }
        public Expression<Func<T, object>> OrderDesc { get ; set; }

        public BaseSpecification()
        {
        
            
        }
        public BaseSpecification(Expression<Func<T, bool>> expression)
        {
            Condition = expression;

        }


    }
}
