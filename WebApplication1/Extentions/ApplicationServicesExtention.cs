using Talabat.Access.Models.Company;
using Talabat.Access.Models;
using Talabat.Core.Interfaces.Repository;
using Talabat.presentations.Helpers;
using Talabat.Repo.Data.Contexts;
using Talabat.Repo.Repositories;
using Talabat.Repos.Data.Contexts;
using Talabat.Repos.Repositories;
using Microsoft.AspNetCore.Mvc;
using Talabat.presentations.Errors;

namespace Talabat.presentations.Extentions
{
    public static class ApplicationServicesExtention
    {
        public static IServiceCollection AddSevices(this IServiceCollection services,IConfiguration conf)
        {
           services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

    
            //WebBuilder.Services.AddScoped<IGenericRepository<Brand>,GenericRepositroy<Brand>>();
            //WebBuilder.Services.AddScoped<IGenericRepository<Category>,GenericRepositroy<Category>>();
            //WebBuilder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddScoped(typeof(IGenericRepository<Product>), typeof(GenericRepository<Product>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(GenericRepository<>));
            services.AddScoped(typeof(GenericRepository<Employee>));
            services.AddScoped(typeof(EmployeeReps));
            //WebBuilder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //WebBuilder.Services.AddAutoMapper(m=>m.AddProfile(new MappingProfile()));
           services.AddAutoMapper(typeof(MappingProfile));
            
            services.AddAutoMapper(m => m.AddProfile(new MappingProfile(conf)));


            // change build-in validation handeler
           services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = actioncontext => {

                    var errors = actioncontext.ModelState
                              .Where(p => p.Value.Errors.Count() > 0)
                              .SelectMany(p => p.Value.Errors)
                              .Select(E => E.ErrorMessage)
                              .ToList();

                    var response = new ApiValidations() { Details = errors };
                    return new BadRequestObjectResult(response);
                };

            });


            return services;

        }
    }
}
