using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Access.Models;
using Talabat.Core.Interfaces.Repository;
using Talabat.presentaion.Controllers;
using Talabat.presentations.Errors;

namespace Talabat.presentations.Controllers
{

    public class CategoryController : BaseAPIController
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryController(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetAll(string? sort)
        {

           var categories=await _repository.GetAllAsync();


            if (categories is not null)
            {
                return Ok(categories);
            }
            return BadRequest(new ApiResponease(400).ToString());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetWithId(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category is not null)
                return Ok(category);
            return BadRequest(new ApiResponease(400).ToString());
        }

    }
}
