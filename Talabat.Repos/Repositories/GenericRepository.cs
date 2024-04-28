using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Specifications.Product;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Interfaces;
using Talabat.Core.Interfaces.Repository;
using Talabat.Repo.SpecificationImplementation;
using Talabat.Repos.Data.Contexts;

namespace Talabat.Repos.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly StoreDbContext context;

        public GenericRepository(StoreDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IEnumerable<T>)await context.Products.Include(p => p.ProductBrand).Include(p => p.ProductCategory).ToListAsync();
            }
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

    

        public async Task<T?> GetByIdAsync(int id)
        {
            if (typeof(T) == typeof(Product))
            {
                return await context.Products.Where(p => p.Id == id).Include(p => p.ProductCategory).Include(p => p.ProductBrand).FirstOrDefaultAsync() as T;
            }
            return await context.Set<T>().FindAsync(id);
        }
    
        public async Task<IEnumerable<T>> GetAllWithSpecAsync(IBaseSpecification<T> spec)
        {
            return await _creatSpec(spec).ToListAsync();
        }
        public async Task<T?> GetByIdWithSpecAsync(IBaseSpecification<T> spec)
        {
          
            return await _creatSpec(spec).FirstOrDefaultAsync();
        }
    

    private IQueryable<T> _creatSpec(IBaseSpecification<T> spec)
        {

            return SpecificationCreator<T>.CreateQuery(context.Set<T>(), spec);
        }
    }
}
