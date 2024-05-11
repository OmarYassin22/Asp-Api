using Talabat.Access.Models.Company;
using Talabat.Access.Models;
using Talabat.presentations.Helpers;
using Talabat.Repo.Repositories;
using Talabat.Repos.Data.Contexts;
using Talabat.Repos.Repositories;
using Microsoft.AspNetCore.Mvc;
using Talabat.presentations.Errors;
using Talabat.Core.Interfaces;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;
using Talabat.Repo.Identity;
using Microsoft.AspNetCore.Identity;
using Talabat.presentations.Identity;
using Talabat.Repo.Identity.Migrations;

namespace Talabat.presentations.Extentions
{
    public static class ApplicationServicesExtention
    {
        public static IServiceCollection AddSevices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen();


            services.AddScoped(typeof(IGenericRepository<Product>), typeof(GenericRepository<Product>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(GenericRepository<>));
            services.AddScoped(typeof(GenericRepository<Employee>));
            services.AddScoped(typeof(EmployeeReps));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddAutoMapper(m => m.AddProfile(new MappingProfile(conf)));


            // change build-in validation handeler
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actioncontext) =>
                {

                    var errors = actioncontext.ModelState
                              .Where(p => p.Value.Errors.Count() > 0)
                              .SelectMany(p => p.Value.Errors)
                              .Select(E => E.ErrorMessage)
                              .ToList();

                    var response = new ApiValidations() { Details = errors };
                    return new BadRequestObjectResult(response);
                };




            });


         
            // normal depenpany injection
            services.AddScoped<IBasketRepostory,BasketRepository>();
            // Generic depenpany injection
            services.AddScoped(typeof(IBasketRepostory), typeof(BasketRepository));


            //register identity services
            services.AddIdentity<ApplicationUser, IdentityRole>(options => {}).
                // add identy store => needed with usermanger
                AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            

            return services;

        }
    }
}
