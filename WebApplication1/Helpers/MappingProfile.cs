using AutoMapper;
using Talabat.Access.Models;
using Talabat.Access.Models.Company;
using Talabat.Core.Models.Customer;
using Talabat.Core.Models.Oreder_Aggregate;
using Talabat.presentations.DTOs;
using Talabat.presentations.Identity;
using static System.Net.WebRequestMethods;
using Address = Talabat.presentations.Identity.Address;

namespace Talabat.presentations.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IConfiguration conf)
        {
            CreateMap<Product, ProductDTO>().
                ForMember(d => d.ProductBrand, O => O.MapFrom(s => s.ProductBrand.Name)).
                ForMember(d => d.ProductCategory, O => O.MapFrom(s => s.ProductCategory.Name))
              //.ReverseMap();  
              .ForMember(d => d.PictureUrl, O => O.MapFrom(d => $"{conf["BaseUrl"]}{d.PictureUrl}")).ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().
             ForMember(d => d.ProductBrand, O => O.MapFrom(s => s.ProductBrand.Name)).
             ForMember(d => d.ProductCategory, O => O.MapFrom(s => s.ProductCategory.Name))
          .ForMember(d => d.PictureUrl, O => O.MapFrom<ProductPictureResolver>());
            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<OrderAddress, OrderAddressDto>().
                ReverseMap(); 
            CreateMap<OrderAddress, AddressDto>().
                ReverseMap();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, O => O.MapFrom(s => s.Product.ProductId))
                .ForMember(d => d.ProductName, O => O.MapFrom(s => s.Product.ProductName))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<OrderItemPictureResolver>())
                .ReverseMap();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethodCost, O => O.MapFrom(s => s.DeliveryMethod.Cost))
                .ForMember(d=>d.DeliveryMethod , O=>O.MapFrom(s=>s.DeliveryMethod.Name))
                
                // no need to tell clr to convert from int to string as we declare it in Dto string with same name
                //.ForMember(d => d.Status, O => O.MapFrom(s => s.Status))
               
                // will use configuration between orderItem and OrderITemDto automaticlly
                // .ForMember(d=>d.Items,O=>O.MapFrom(s=>s.Items ))
                .ReverseMap();



        }
    }
}
