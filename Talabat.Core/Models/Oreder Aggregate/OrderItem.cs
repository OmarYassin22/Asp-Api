using Talabat.Access.Models;

namespace Talabat.Core.Models.Oreder_Aggregate
{
    public class OrderItem:BaseModel
    {
        private OrderItem()
        {
            
        }
        public OrderItem(ProductItemOrder product, decimal price, int qunatity)
        {
            Product = product;
            Price = price;
            Qunatity = qunatity;
        }

        public ProductItemOrder Product { get; set; } = null!;
        public decimal Price { get; set; }
        public int Qunatity { get; set; }
    }
}
