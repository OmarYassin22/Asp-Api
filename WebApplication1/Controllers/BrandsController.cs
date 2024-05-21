using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Classes;
using Talabat.Access.Specifications.Product.Interfaces;
using Talabat.Core.Interfaces.Serviece;
using Talabat.presentaion.Controllers;
using Talabat.presentations.Errors;
using Talabat.Repos.Data.Contexts;

namespace Talabat.presentations.Controllers
{

    public class BrandsController : BaseAPIController
    {
        //private readonly IGenericRepository<Brand> _context;
        private readonly IBrandServieces _brandServieces;

        public BrandsController(/*IGenericRepository<Brand> context*/ IBrandServieces brandServieces)
        {
            //_context = context;
            _brandServieces = brandServieces;
        }
        [HttpGet]
        public async Task< ActionResult<IEnumerable<Brand>>> GetAll()
        {

            
            var result = await _brandServieces.GetBrandsAsync();
            if (result is not null)

                return Ok(result);
            return BadRequest(new ApiResponease(400).ToString());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> Get(int id)
        {
            
            var result = await _brandServieces.GetBrandAsync(id);
            if (result is not null)
                return Ok(result); 
            return BadRequest(new ApiResponease(400).ToString());

        }
    }
}
