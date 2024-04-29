using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Classes;

namespace Talabat.Access.Specifications.ProductSpecification
{
    public class ProductWithSpecifications : BaseSpecification<Models.Product>
    {
        public ProductWithSpecifications(string? sort="name") : base()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductCategory);
            Order = Order;
            
            switch (sort?.ToLower())
            {
                case "namedesc":
                    OrderDesc = p => p.Name;
                    break;
                case "priceasc":
                       Order = p => p.Price;
                    break;
                case "pricedesc":
                    OrderDesc = p => p.Price;
                    break;
                default:
                    Order = p => p.Name;

                    break;
            }
        }
        public ProductWithSpecifications(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductCategory);
        }

    }
}
