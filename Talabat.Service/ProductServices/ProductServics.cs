using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Access.Specifications.ProductSpecification;
using Talabat.Core.Interfaces;
using Talabat.presentations.Helpers;

namespace Talabat.Service.ProductServices
{
    public class ProductServics : IProductServices
    {
        private readonly IUnitOFWork _unitOFWork;

        public ProductServics(IUnitOFWork unitOFWork)
        {
            unitOFWork = unitOFWork;
        }
        public Task<Product> GetProductAsync(int Id)
        {
            /*  var products = _unitOFWork.Repository<Product>();
              var spec = new ProductWithSpecifications(new ProductSpecParams());
              var result = products.GetByIdWithSpecAsync(spec);
              if (result is null) return null;
              return result

              throw new NotImplementedException();*/
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
