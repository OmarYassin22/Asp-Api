using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Classes;
using Talabat.Access.Specifications.Product.Interfaces;
using Talabat.Core.Interfaces.Repository;
using Talabat.presentaion.Controllers;
using Talabat.presentations.Errors;
using Talabat.Repos.Data.Contexts;

namespace Talabat.presentations.Controllers
{

    public class BrandController : BaseAPIController
    {
        private readonly IGenericRepository<Brand> _context;

        public BrandController(IGenericRepository<Brand> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task< ActionResult<IEnumerable<Brand>>> GetAll()
        {

            var spec= new BaseSpecification<Brand>();  
            var result = await _context.GetAllWithSpecAsync(spec);
            if (result is not null)

                return Ok(result);
            return BadRequest(new ApiResponease(400).ToString());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> Get(int id)
        {
            var spec = new BaseSpecification<Brand>(c=>c.Id==id);
            var result = await _context.GetByIdWithSpecAsync(spec);
            if (result is not null)
                return Ok(result); 
            return BadRequest(new ApiResponease(400).ToString());

        }
    }
}
