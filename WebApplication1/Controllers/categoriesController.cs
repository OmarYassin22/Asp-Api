using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product.Classes;
using Talabat.Core.Interfaces.Serviece;
using Talabat.presentaion.Controllers;
using Talabat.presentations.Errors;

namespace Talabat.presentations.Controllers
{

    public class categoriesController : BaseAPIController
    {
        //private readonly IGenericRepository<Category> _repository;
        private readonly ICategorySrevices _categorySrevices;

        public categoriesController(/*IGenericRepository<Category> repository*/
            ICategorySrevices categorySrevices
            )
        {
            //_repository = repository;
            _categorySrevices = categorySrevices;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetAll()
        {

            var categories =await   _categorySrevices.GetCategoriesAsync();


            if (categories is not null)
            {
                return Ok(categories);
            }
            return BadRequest(new ApiResponease(400).ToString());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetWithId(int id)
        {
            //var category = await _repository.GetByIdAsync(id);
            var category = await _categorySrevices.GetCategoryAsync(id);

            if (category is not null)
                return Ok(category);
            return BadRequest(new ApiResponease(400).ToString());
        }

    }
}
