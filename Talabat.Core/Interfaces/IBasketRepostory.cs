using Talabat.Core.Models.Customer;

namespace Talabat.Core.Interfaces
{
    public interface IBasketRepostory

    {
        Task<CustomerBasket?> GetBasketAsync(string id);
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string id);

    }
}
