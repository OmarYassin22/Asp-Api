using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.presentations.DTOs
{
    public class OrderDto
    {
        public string BuyerEmail { get; set; }
        public AddressDto Address { get; set; }
        public int DeliveryMethodId { get; set; }
        public string BasketId { get; set; }


    }
}
