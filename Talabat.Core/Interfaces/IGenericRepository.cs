using Talabat.Access.Models;
using Talabat.Access.Specifications.Product;
using Talabat.Access.Specifications.Product.Classes;
using Talabat.Access.Specifications.Product.Interfaces;

namespace Talabat.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdWithSpecAsync(IBaseSpecification<T> spec);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithSpecAsync(IBaseSpecification<T> spec);
        Task<int> GetCountAsync(IBaseSpecification<T> spec);
    }
}
