using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;

namespace Talabat.Core.Interfaces
{
    public interface IBrandServieces
    {
        Task<IReadOnlyList<Brand>> GetBrandsAsync();
        Task<Brand> GetBrandAsync(int id);
    }
}
