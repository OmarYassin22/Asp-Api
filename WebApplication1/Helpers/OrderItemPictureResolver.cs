using AutoMapper;
using Talabat.Core.Models.Oreder_Aggregate;
using Talabat.presentations.DTOs;

namespace Talabat.presentations.Helpers
{
    public class OrderItemPictureResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _conf;

        public OrderItemPictureResolver(IConfiguration conf)
        {
            _conf = conf;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if(source is not null)
            return $"{_conf["BaseUrl"] + source.Product.PictureUrl}";
            return string.Empty;
        }
    }
}