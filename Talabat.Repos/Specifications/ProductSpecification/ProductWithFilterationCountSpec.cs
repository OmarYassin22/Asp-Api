using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Classes;
using Talabat.presentations.Helpers;

namespace Talabat.Repo.Specifications.ProductSpecification
{
    public class ProductWithFilterationCountSpec : BaseSpecification<Product>
    {
        public ProductWithFilterationCountSpec(ProductSpecParams parames)
            : base(p =>
                 (!parames.brandId.HasValue || p.BrandId == parames.brandId) &&
                 (!parames.CategoryId.HasValue || p.CategoryId == parames.CategoryId) &&
            (string.IsNullOrEmpty(parames.Search) || p.Name.ToLower().Contains(parames.Search)
            )


            )

        {

        }
    }
}
