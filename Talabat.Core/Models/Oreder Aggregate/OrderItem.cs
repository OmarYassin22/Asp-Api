using Talabat.Access.Models;

namespace Talabat.Core.Models.Oreder_Aggregate
{
    public class OrderItem:BaseModel
    {
        public ProductItemOrder Product { get; set; } = null!;
        public decimal Price { get; set; }
        public int Qunatity { get; set; }
    }
}
