using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Core.Interfaces;

namespace Talabat.Service
{
    public class CategoryServices : ICategorySrevices
    {
        private readonly IUnitOFWork _unitOFWork;

        public CategoryServices(IUnitOFWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }
        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
       => await _unitOFWork.Repository<Category>().GetAllAsync() as IReadOnlyList<Category>;

        public Task<Category> GetCategoryAsync(int id)
        => _unitOFWork.Repository<Category>().GetByIdAsync(id);
    }
}
