using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Interfaces;
using Talabat.presentations.Helpers;

namespace Talabat.Core.Interfaces.Serviece
{
    public interface IProductServices
    {
        Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams param);
        Task<Product> GetProductAsync(int Id);
        Task<int> GetProductCount(ProductSpecParams param);
    }
}
