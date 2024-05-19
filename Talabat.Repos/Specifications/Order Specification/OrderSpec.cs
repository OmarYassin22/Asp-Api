using Talabat.Access.Specifications.Product.Classes;
using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.Repo.Specifications.Order_Specification
{
    public class OrderSpec : BaseSpecification<Order>
    {
        public OrderSpec(string userEmail):base(o=>o.BuyerEmail==userEmail)
        {
            Includes.Add(o => o.DeliveryMethod);
            Includes.Add(o => o.Items);
            SetOrderByDesc(o=>o.OrderDate);  
        }
        public OrderSpec(string userEmail,int Id) : base(o => o.Id == Id&& o.BuyerEmail == userEmail)
        {
            Includes.Add(o => o.DeliveryMethod);
            Includes.Add(o => o.Items);
            SetOrderByDesc(o => o.OrderDate);
        }

    }
}
