using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Talabat.Access.Models;
using Talabat.Access.Specifications.ProductSpecification;
using Talabat.Core.Interfaces;
using Talabat.Core.Interfaces.Serviece;
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
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductsController(GenericRepository<Product> Products,IProductServices productServices, IMapper mapper)
        {
            _products = Products;
            _productServices = productServices;
            _mapper = mapper;
        }
        //[Authorize(AuthenticationSchemes ="Bearer")] //=> not need to determine sechema as we made it deault one in AddAuthentication services
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetAllProducts([FromQuery]ProductSpecParams specParames)
        {


            //WIthout UnitOFWork
            /*var spec = new ProductWithSpecifications(specParames);

            var pros = await _products.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList< ProductDTO>>(pros);
            var countSpec = new ProductWithFilterationCountSpec(specParames);
            var count =await _products.GetCountAsync(countSpec);
            return Ok(result);*/
            //With UnitOFWork
           
            var product = await _productServices.GetProductsAsync(specParames);
            var data = _mapper.Map<IReadOnlyList<ProductDTO>>(product);
            var count = await _productServices.GetProductCount(specParames);
            var result = new PaginationResponse<ProductDTO>(data, specParames.PageIndex, specParames.PageSize,count);


            return Ok(result);

        }

        [HttpGet(template:"{id}")]

        [ProducesResponseType(typeof(ProductDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponease),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {


            //var product = await _products.GetByIdAsync(id);
           /* var spec=new ProductWithSpecifications(id);
           
            var product =await _products.GetByIdWithSpecAsync(spec);

            if (product is not null)
            {
             var result= _mapper.Map<ProductDTO>(product);
                return Ok(result);
            }
            return NotFound(new ApiResponease(404).ToString());*/

            var product =await _productServices.GetProductAsync(id);

            if (product is not null)
            {
                var result = _mapper.Map<ProductDTO>(product);
                return Ok(result);
            }
            return NotFound(new ApiResponease(404).ToString());
        }

    }
}
