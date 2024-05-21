using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Interfaces.Serviece;
using Talabat.Core.Models.Customer;
using Talabat.presentaion.Controllers;
using Talabat.presentations.Errors;

namespace Talabat.presentations.Controllers
{
    [Authorize]
    public class PaymentController : BaseAPIController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{id}")]
    public async Task<ActionResult<CustomerBasket>> GetOrUPdate(string id)
        {
            var basket = await _paymentService.CreateOrUpdateAsync(id);
            if (basket == null) return BadRequest(new ApiResponease(400,"There is error with your Basket"));

            return Ok(basket);
        }
    }
}
