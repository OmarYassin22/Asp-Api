using System.ComponentModel.DataAnnotations;
using Talabat.Core.Models.Customer;

namespace Talabat.presentations.DTOs
{
    public class CustomerBasketDto
    {
        public CustomerBasketDto(string id)
        {
            Id = id;
            Items = new List<BasketItemDto>();
        }

        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
