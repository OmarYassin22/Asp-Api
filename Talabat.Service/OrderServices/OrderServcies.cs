using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Interfaces;
using Talabat.Core.Models.Customer;
using Talabat.Core.Models.Oreder_Aggregate;
using Talabat.Repos.Data.Contexts;

namespace Talabat.Service.OrderServices
{
    public class OrderServcies : IOrderServices
    {
        private readonly StoreDbContext _context;
        private readonly IDatabase _redis;

        public OrderServcies(StoreDbContext context,IConnectionMultiplexer redis)
        {
            _context = context;
            _redis = redis.GetDatabase();
        }

        public async Task<Core.Models.Oreder_Aggregate.Order> CreateOderAsync(string BasketId, string BuyerEmai, Address address)
        {
            var basket = await _redis.StringGetAsync(BasketId);
            var items= JsonSerializer.Deserialize<List<CustomerBasket>>(basket);

            var ProductItems= new List<ProductItem>()
            foreach (var item in items)
            {
                
            }
            var ids = items.Select(i => i.Id).ToList();
            var products = _context.Products.Aggregate(it=>it.Id==ids);
           

            _context.Orders.Add()

        }
    }
}
