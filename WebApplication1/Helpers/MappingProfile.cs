using AutoMapper;
using Talabat.Access.Models;
using Talabat.Access.Models.Company;
using Talabat.Core.Models.Customer;
using Talabat.presentations.DTOs;
using Talabat.presentations.Identity;
using static System.Net.WebRequestMethods;

namespace Talabat.presentations.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile(IConfiguration conf)
        {
            CreateMap<Product, ProductDTO>().
                ForMember(d => d.ProductBrand, O => O.MapFrom(s=> s.ProductBrand.Name)).
                ForMember(d => d.ProductCategory, O => O.MapFrom(s => s.ProductCategory.Name))
              //.ReverseMap();  
              .ForMember(d => d.PictureUrl, O => O.MapFrom(d=>$"{conf["BaseUrl"]}{d.PictureUrl}")).ReverseMap();

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

        }
    }
}
