using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.Access.Models;
using Talabat.Access.Specifications.ProductSpecification;
using Talabat.Core.Interfaces;
using Talabat.presentations.DTOs;
using Talabat.presentations.Errors;
using Talabat.presentations.Helpers;
using Talabat.Repo.Specifications.ProductSpecification;
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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts([FromQuery]ProductSpecParams specParames)
        {
       


            var spec = new ProductWithSpecifications(specParames);

            var pros = await _products.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList< ProductDTO>>(pros);
            var countSpec = new ProductWithFilterationCountSpec(specParames);
            var count =await _products.GetCountAsync(countSpec);
            var result = new Pagination<ProductDTO>(data, specParames.PageIndex, specParames.PageSize,count);
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
