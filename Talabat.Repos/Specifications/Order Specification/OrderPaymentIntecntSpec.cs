using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Access.Specifications.Product.Classes;
using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.Repo.Specifications.Order_Specification
{
    public class OrderPaymentIntecntSpec:BaseSpecification<Order>
    {
        public OrderPaymentIntecntSpec(string? paymentIntentId):base(o=>o.PaymentIntentId==paymentIntentId)
        {
            
        }
    }
}
