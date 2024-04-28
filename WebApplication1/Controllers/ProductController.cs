using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.Access.Models;
using Talabat.Access.Specifications.Product;
using Talabat.Access.Specifications.ProductSpecification;
using Talabat.Core.Interfaces.Repository;
using Talabat.presentations.DTOs;
using Talabat.presentations.Errors;
using Talabat.presentations.Helpers;
using Talabat.Repos.Data.Contexts;
using Talabat.Repos.Repositories;

namespace Talabat.presentaion.Controllers
{

    public class ProductsController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _products;
        private readonly IMapper _mapper;

        public ProductsController(GenericRepository<Product> Products, IMapper mapper)
        {
            _products = Products;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts([FromQuery]string? sort)
        {

            //var pros = await _products.GetAllAsync();

            //var result= new JsonResult(product);
            //var product= new OkResult();

            var spec = new ProductWithSpecifications(sort);

            var pros = await _products.GetAllWithSpecAsync(spec);
            var result = _mapper.Map<IEnumerable< ProductDTO>>(pros);

            return Ok(result);

        }

        [HttpGet(template:"{id}")]

        [ProducesResponseType(typeof(ProductDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponease),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {


            //var product = await _products.GetByIdAsync(id);
            var spec=new ProductWithSpecifications(id);
           
            var product =await _products.GetByIdWithSpecAsync(spec);

            if (product is not null)
            {
             var result= _mapper.Map<ProductDTO>(product);
                return Ok(result);
            }
            return NotFound(new ApiResponease(404).ToString());

        }

    }
}
