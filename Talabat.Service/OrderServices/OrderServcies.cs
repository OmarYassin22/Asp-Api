using Microsoft.AspNetCore.Http.HttpResults;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Access.Models;
using Talabat.Core.Interfaces;
using Talabat.Core.Interfaces.Serviece;
using Talabat.Core.Models.Customer;
using Talabat.Core.Models.Oreder_Aggregate;
using Talabat.Repo.Repositories;
using Talabat.Repo.Specifications.Order_Specification;
using Talabat.Repos.Data.Contexts;
using Talabat.Service.PaymentService;
using Order = Talabat.Core.Models.Oreder_Aggregate.Order;

namespace Talabat.Service.OrderServices
{
    public class OrderServcies : IOrderServices
    {
        private readonly IBasketRepostory _basketRepository;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IPaymentService _paymentService;

        //private readonly IGenericRepository<Product> _productRepo;
        //private readonly IGenericRepository<Order> _ordeRepo;

        public OrderServcies(
            IBasketRepostory basketRepository,

            /* IGenericRepository<Product> productRepo,
             IGenericRepository<Order> ordeRepo*/

            IUnitOFWork unitOFWork,
            IPaymentService paymentService
            )
        {
            _basketRepository = basketRepository;
            _unitOFWork = unitOFWork;
            _paymentService = paymentService;
            //    _productRepo = unitOFWork.Repository<Product>();
            //    _ordeRepo = unitOFWork.Repository<Order>();
        }

        public async Task<Order?> CreateOderAsync(string BasketId, OrderAddress address, string BuyerEmail, int delevalryMethodID)
        {
            // get basket
            var basket = await _basketRepository.GetBasketAsync(BasketId);

            // get products from DB
            if (basket?.Items?.Count > 0)
            {

                var OrderItems = new List<OrderItem>();
                foreach (var item in basket.Items)
                {
                    var pro = await _unitOFWork.Repository<Product>().GetByIdAsync(item.Id);

                    OrderItems.Add(new OrderItem(new ProductItemOrder(pro.Id, pro.Name, pro.PictureUrl), pro.Price, item.Quantity));
                }
                // cal subtotoal
                var SubTotal = OrderItems.Sum(item => item.Price * item.Qunatity);

                var delevarymethod = await _unitOFWork.Repository<DeliveryMethod>().GetByIdAsync(delevalryMethodID);

                var orderRepo = _unitOFWork.Repository<Order>();

                

                var spec = new OrderPaymentIntecntSpec(basket.PaymentIntedID);
                var existingOrder = await orderRepo.GetByIdWithSpecAsync(spec);
                //chenck if order done befor
                if (existingOrder is not null) {
                    orderRepo.Delete(existingOrder);


                }
                basket=    await _paymentService.CreateOrUpdateAsync(basket.Id);

                // create order
                var order = new Order(

                    buyerEmail: BuyerEmail,
                    shippingAddress: address,
                    deliveryMethod: delevarymethod,
                    items: OrderItems,
                    subTotal: SubTotal,
                    paymentIntentId: basket.PaymentIntedID
                    );

                // add order to DB
                    orderRepo.Add(order);
                var result = await _unitOFWork.CompleteAsync();
                if (result <= 0) return null;
                return order;

            }
            return null;

        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(string UserEmail)
        {

            var Orders = _unitOFWork.Repository<Order>();
            var spec = new OrderSpec(UserEmail);
            var result = await Orders.GetAllWithSpecAsync(spec);
            if (result?.Count() == 0) return null;
            return result;
        }

        public async Task<Order> GetOrderAsync(string UserEmail,int id)
        {
            var Orders= _unitOFWork.Repository<Order>();    
            var spec = new OrderSpec(UserEmail, id);
            var result = await Orders.GetByIdWithSpecAsync(spec);
            return result;


        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDilevaryMethodAsync()
        =>await _unitOFWork.Repository<DeliveryMethod>().GetAllAsync() as IReadOnlyList<DeliveryMethod> ;
    }
}
