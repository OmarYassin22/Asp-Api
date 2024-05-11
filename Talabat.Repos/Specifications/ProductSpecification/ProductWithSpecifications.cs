using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Classes;
using Talabat.presentations.Helpers;

namespace Talabat.Access.Specifications.ProductSpecification
{
    public class ProductWithSpecifications : BaseSpecification<Models.Product>
    {
        public ProductWithSpecifications(ProductSpecParams Parames ) : base()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductCategory);
            Condition = p => (!Parames.brandId.HasValue || p.BrandId == Parames.brandId.Value)
                        && (!Parames.CategoryId.HasValue || p.CategoryId == Parames.CategoryId.Value)
                        && (string.IsNullOrEmpty(Parames.Search)|| p.Name.ToLower().Contains(Parames.Search));
           
            ApplyPagination(Parames.PageSize * (Parames.PageIndex - 1), Parames.PageSize);
            switch (Parames.sort?.ToLower())
            {
                case "namedesc":
                    SetOrderByDesc(p => p.Name);
                    //OrderDesc = p => p.Name;
                    break;
                case "priceasc":
                    SetOrderBy(p => p.Price);
                       //Order = p => p.Price;
                    break;
                case "pricedesc":
                    SetOrderByDesc(p => p.Price);
                    //OrderDesc = p => p.Price;
                    break;
                default:
                    SetOrderBy(p => p.Name);

                    //Order = p => p.Name;

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
