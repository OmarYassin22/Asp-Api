using StackExchange.Redis;
using System.Text.Json;
using Talabat.Core.Interfaces;
using Talabat.Core.Models.Customer;

namespace Talabat.Repo.Repositories
{
    public class BasketRepository : IBasketRepostory
    {
        private readonly IDatabase _redis;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string id)
       => await _redis.KeyDeleteAsync(id);

        

        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            var basket = await _redis.StringGetAsync(id);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var flage = await _redis.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (flage is false) return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}
