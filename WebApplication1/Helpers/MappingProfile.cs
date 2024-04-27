using AutoMapper;
using Talabat.Access.Models;
using Talabat.Access.Models.Company;
using Talabat.presentations.DTOs;
using static System.Net.WebRequestMethods;

namespace Talabat.presentations.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile(IConfiguration conf)
        {
            CreateMap<Product,ProductDTO>().
                ForMember(d=>d.ProductBrand,O=>O.MapFrom(s=>s.ProductBrand.Name)).
                ForMember(d => d.ProductCategory, O => O.MapFrom(s => s.ProductCategory.Name))
              .ForMember(d=>d.PictureUrl,O=>O.MapFrom< ProductPictureResolver>())
              //.ReverseMap();  
              .ForMember(d => d.PictureUrl, O => O.MapFrom(d => conf["BaseUrl"]+d.PictureUrl)).ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
