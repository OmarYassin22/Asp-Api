using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Interfaces;
using Talabat.Core.Models.Customer;
using Talabat.presentaion.Controllers;
using Talabat.presentations.DTOs;
using Talabat.presentations.Errors;
using Talabat.Repo.Repositories;

namespace Talabat.presentations.Controllers
{
    public class BasketController : BaseAPIController
    {
        private readonly IBasketRepostory _repostory;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepostory repostory, IMapper mapper)
        {
            _repostory = repostory;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponease), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IBasketRepostory), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CustomerBasketDto>>> Get(string id)
        {


            var basket = _mapper.Map<CustomerBasket,CustomerBasketDto>(await _repostory.GetBasketAsync(id));
            return Ok(basket ?? new CustomerBasketDto(id));


        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateOrCreate(CustomerBasketDto basket)
        {
            var response = await _repostory.UpdateBasketAsync(_mapper.Map<CustomerBasketDto,CustomerBasket>( basket));
            if (response is null) return BadRequest(new ApiResponease(400));
            return Ok(response);
        }
        [HttpDelete]
        public async Task Delete(string id)
        {

            await _repostory.DeleteBasketAsync(id);

        }
    }
}
