using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.Core.Interfaces
{
    public interface IOrderServices
    {
        Task<Order> CreateOderAsync(string BasketId, string BuyerEmai, Address address);
    }
}
