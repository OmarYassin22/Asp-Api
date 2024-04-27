using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Classes;

namespace Talabat.Access.Specifications.ProductSpecification
{
    public class ProductWithSpecifications : BaseSpecification<Talabat.Access.Models.Product>
    {
        public ProductWithSpecifications() : base()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductCategory);

        }
        public ProductWithSpecifications(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductCategory);
        }

    }
}
