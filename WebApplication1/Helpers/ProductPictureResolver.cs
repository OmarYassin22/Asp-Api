using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Internal;
using System.Linq.Expressions;
using System.Reflection;
using Talabat.Access.Models;
using Talabat.presentations.DTOs;

namespace Talabat.presentations.Helpers
{
    public class ProductPictureResolver : IValueResolver<Product,ProductDTO,string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (source is not null)
            {
                return $"{_configuration["BaseUrl"]}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
