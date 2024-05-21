using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Interfaces;
using Talabat.Access.Specifications.ProductSpecification;
using Talabat.Core.Interfaces;
using Talabat.Core.Interfaces.Serviece;
using Talabat.presentations.Helpers;
using Talabat.Repo.Specifications.ProductSpecification;

namespace Talabat.Service.ProductServices
{
    public class ProductServics : IProductServices
    {
        private readonly IUnitOFWork _unitOFWork;

        public ProductServics(IUnitOFWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }
        public Task<Product> GetProductAsync(int Id)
        {
            var products = _unitOFWork.Repository<Product>();
            var spec=new ProductWithSpecifications(Id);

            var result = products.GetByIdWithSpecAsync(spec);
            if (result is null) return null;
            return result;

        }

        public async Task<int> GetProductCount(ProductSpecParams param)
        {
            var product=_unitOFWork.Repository<Product>();

            var countSpec = new ProductWithFilterationCountSpec(param);

            return await product.GetCountAsync(countSpec);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams param)
        {
            var products = _unitOFWork.Repository<Product>();
            var spec = new ProductWithSpecifications(param);
            var result = await products.GetAllWithSpecAsync(spec);
            if (result is null) return null;
            return result as IReadOnlyList<Product> ;
        }

      
    }
}
