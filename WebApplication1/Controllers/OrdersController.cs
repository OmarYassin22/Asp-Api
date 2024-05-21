using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using Talabat.Core.Interfaces.Serviece;
using Talabat.Core.Models.Oreder_Aggregate;
using Talabat.presentaion.Controllers;
using Talabat.presentations.DTOs;
using Talabat.presentations.Errors;
using Talabat.Service.OrderServices;

namespace Talabat.presentations.Controllers
{

    [Authorize]
    public class OrdersController : BaseAPIController
    {
        private readonly IOrderServices _services;
        private readonly IMapper _mapper;

        public OrdersController(IOrderServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto order)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await _services.CreateOderAsync(order.BasketId, _mapper.Map<OrderAddress>(order.Address), email, order.DeliveryMethodId);
            if (result is null) return BadRequest(new ApiResponease(401));
            return Ok(result);



        }

        [HttpGet]
        public async Task<IReadOnlyList<OrderToReturnDto>> GetOrders()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await _services.GetOrdersAsync(email);
            if (result is null) return null;
            var respone = _mapper.Map<IReadOnlyList<OrderToReturnDto>>(result);
            return respone;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderToReturnDto), 200)]
        [ProducesResponseType(typeof(ApiResponease), 404)]
        public async Task<ActionResult<OrderToReturnDto>> GetOrder(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await _services.GetOrderAsync(email, id);
            if (result is null) return BadRequest(new ApiResponease(404));
            var response = _mapper.Map<OrderToReturnDto>(result);

            return response;

        }

        [HttpGet("deliverymethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDelevary()

        => Ok(await _services.GetDilevaryMethodAsync());
        


    }
}