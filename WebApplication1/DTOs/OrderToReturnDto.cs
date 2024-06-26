﻿using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.presentations.DTOs
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }

        public string BuyerEmail { get; set; } = null!;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public string Status { get; set; }
        public OrderAddress ShippingAddress { get; set; } = null!;
        public string DeliveryMethod { get; set; }
        public decimal DeliveryMethodCost { get; set; }
        public ICollection<OrderItemDto> Items { get; set; } = new HashSet<OrderItemDto>();
        public decimal SubTotal { get; set; }

       
        public decimal Total{ get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}
