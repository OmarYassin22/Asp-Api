using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Core.Interfaces;
using Talabat.Core.Models.Oreder_Aggregate;
using Talabat.Repos.Data.Contexts;
using Talabat.Repos.Repositories;

namespace Talabat.Repo.Repositories
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly StoreDbContext _dbContext;
        //private Dictionary<string, IGenericRepository<BaseModel>> _repostiries;
        private Hashtable _repostiries;
        
        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            //_repostiries = new Dictionary<string, IGenericRepository<BaseModel>>();
            _repostiries = new Hashtable();
        }
        
        public IGenericRepository<T> Repository<T>() where T : BaseModel
        {
            var key = typeof(T).Name;
            if(!_repostiries.ContainsKey(key)) {

                var repo = new GenericRepository<T>(_dbContext);
                _repostiries.Add(key ,repo);
            }

            return _repostiries[key] as IGenericRepository<T>;

        }
        public async Task<int> CompleteAsync()
            => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
        => await _dbContext.DisposeAsync();

        
    }
}
