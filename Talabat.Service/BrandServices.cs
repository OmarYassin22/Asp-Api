using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Core.Interfaces;

namespace Talabat.Service
{
    public class BrandServices : IBrandServieces
    {
        private readonly IUnitOFWork _unitOFWork;

        public BrandServices(IUnitOFWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }
        public async Task<Brand> GetBrandAsync(int id)
        => await _unitOFWork.Repository<Brand>().GetByIdAsync(id);

        public async Task<IReadOnlyList<Brand>> GetBrandsAsync()
        => await _unitOFWork.Repository<Brand>().GetAllAsync() as IReadOnlyList<Brand>;
    }
}
