namespace Talabat.presentations.DTOs
{
    public class OrderItemDto
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public string PictureUrl { get; set; } 
        public decimal Price { get; set; }
        public int Qunatity { get; set; }
    }
}