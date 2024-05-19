using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.Core.Interfaces
{
    public interface IUnitOFWork:IAsyncDisposable
    {
        IGenericRepository<T> Repository<T>() where T:BaseModel;

        Task<int> CompleteAsync();
    }
}
