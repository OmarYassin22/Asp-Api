﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.Core.Interfaces.Serviece
{
    public interface IOrderServices
    {
        Task<Order?> CreateOderAsync(string BasketId, OrderAddress address, string BuyerEmail, int delevalryMethodID);
        Task<IEnumerable<Order>> GetOrdersAsync(string UserEmail);
        Task<Order> GetOrderAsync(string UserEmail, int id);
        Task<IReadOnlyList<DeliveryMethod>> GetDilevaryMethodAsync();
    }
}
