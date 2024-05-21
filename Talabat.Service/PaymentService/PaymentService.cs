using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Core.Interfaces;
using Talabat.Core.Interfaces.Serviece;
using Talabat.Core.Models.Customer;
using Talabat.Core.Models.Oreder_Aggregate;
using Product = Talabat.Access.Models.Product;

namespace Talabat.Service.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IBasketRepostory _basketRepo;
        private readonly IUnitOFWork _unitOFWork;

        public PaymentService(IConfiguration configuration, IBasketRepostory basketRepo, IUnitOFWork unitOFWork)
        {
            _configuration = configuration;
            _basketRepo = basketRepo;
            _unitOFWork = unitOFWork;
        }
        public async Task<CustomerBasket?> CreateOrUpdateAsync(string baskeId)
        {
            //set secert key
            StripeConfiguration.ApiKey = _configuration["StreipSetting:SecretKey"];


            //Get Basket
            var basket = await _basketRepo.GetBasketAsync(baskeId);
            if (basket is null) return null;
            //Valid Basket Item Price
            if (basket.Items.Count > 0)
            {
                var productRepo = _unitOFWork.Repository<Product>();
                foreach (var item in basket.Items)
                {
                    var product = await productRepo.GetByIdAsync(item.Id);
                    if (item.Price != product.Price) item.Price = product.Price;
                }

            }
            // calc delivery metyhod
            var shippingPrice = 1m;
            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOFWork.Repository<DeliveryMethod>().GetByIdAsync(basket.DeliveryMethodId.Value);
                shippingPrice = deliveryMethod.Cost;
                basket.ShippingPrice = deliveryMethod.Cost;
            }

            PaymentIntent paymentIntent;
            var paymentIntentservice = new PaymentIntentService();
            if (string.IsNullOrEmpty(basket.PaymentIntedID))//Create
            {

                PaymentIntentCreateOptions options = new PaymentIntentCreateOptions()
                {
                    Amount = (long)basket.Items.Sum(item => item.Price * 100 * item.Quantity) + (long)shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>() { "card" }

                };
                paymentIntent = await paymentIntentservice.CreateAsync(options); // integration with Stripe
                basket.PaymentIntedID= paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;
            
            }
            else//Update
            {
                var option= new PaymentIntentUpdateOptions()
                {
                    Amount = (long)basket.Items.Sum(item => item.Price * 100 * item.Quantity) * (long)shippingPrice * 100,
                };
                 await paymentIntentservice.UpdateAsync(basket.PaymentIntedID, option); 

            }
            await _basketRepo.UpdateBasketAsync(basket);
            return basket;

        }
    }
}
