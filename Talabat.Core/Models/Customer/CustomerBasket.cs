﻿namespace Talabat.Core.Models.Customer
{
    public class CustomerBasket
    {

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }

        public string? PaymentIntedID { get; set; }
        public string? ClientSecret { get; set; }
        public int? DeliveryMethodId { get; set; }
        public decimal ShippingPrice { get; set; }
        public CustomerBasket(string id)
        {
        
            Id = id;
            Items = new List<BasketItem>();
        }

    }
}
