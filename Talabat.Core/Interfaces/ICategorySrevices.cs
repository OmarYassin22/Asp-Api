using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;

namespace Talabat.Core.Interfaces
{
    public interface ICategorySrevices
    {
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
    }
}
