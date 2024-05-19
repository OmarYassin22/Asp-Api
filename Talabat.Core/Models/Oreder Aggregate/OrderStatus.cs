using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Models.Oreder_Aggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "pending")]   
        Pending,
        [EnumMember(Value = "Payment Recived")]
        PaymentRecived,
        [EnumMember(Value = "Payment Faild")]
        PaymentFaild,

    }
}
