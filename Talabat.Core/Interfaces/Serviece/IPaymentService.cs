using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models.Customer;

namespace Talabat.Core.Interfaces.Serviece
{
    public interface IPaymentService
    {
        Task<CustomerBasket?> CreateOrUpdateAsync(string baskeId);
    }
}
