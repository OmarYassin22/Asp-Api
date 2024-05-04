using System.ComponentModel.DataAnnotations;

namespace Talabat.presentations.DTOs
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(1, double.MaxValue,ErrorMessage ="Price Can't Be Less Than 1 !!")]
        public decimal Price { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "Quantity Can't Be Less Than 1 !!")]
        public int Quantity { get; set; }
    }
}