﻿using System.ComponentModel.DataAnnotations.Schema;
using Talabat.Access.Models;

namespace Talabat.Core.Models.Oreder_Aggregate
{
    public class Order : BaseModel
    {
        public string BuyerEmail { get; set; } = null!;
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public OrderStatus Status { get; set; }
        public Address ShippingAddress { get; set; } = null!;
        //public int DelliveryMethodId { get; set; }//ForginKey
        public DeliveryMethod? DeliveryMethod { get; set; } = null!;
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public decimal SubTotal { get; set; }

        // made derived attribute
        // 1. use NotMapped attribute
       /* [NotMapped]
        public decimal Total => SubTotal + DeliveryMethod.Cost;*/
    
        //2. made method start with Get => to mapped by convinsion in OrderDto
        public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}
