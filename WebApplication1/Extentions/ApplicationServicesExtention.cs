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
using Talabat.Core.Interfaces.Auth;
using Talabat.Service;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;

namespace Talabat.presentations.Extentions
{
    public static class ApplicationServicesExtention
    {
        
        public static IServiceCollection AddSevices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddControllers()
                // NewtonsoftJson => Package to handle reference looping(two navigatyoin prop)
                .AddNewtonsoftJson(options => { 
            // Ignore ==> to show navigation prop once and stop
            options.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore;
            });
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
            services.AddScoped<IBasketRepostory, BasketRepository>();
            // Generic depenpany injection
            services.AddScoped(typeof(IBasketRepostory), typeof(BasketRepository));


            //register identity services
            services.AddIdentity<ApplicationUser, IdentityRole>(options => { }).
                // add identy store => needed with usermanger
                AddEntityFrameworkStores<ApplicationIdentityDbContext>();

       

            // Authontication services
            services.AddScoped(typeof(IAuthServices), typeof(AuthServices));



            return services;

        }


        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration conf)
        {

            // enable token handler
            services.AddAuthentication(options =>
            {
                // determine default schema tokens
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                // determine default schema for endpoints
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                // handle to
                .AddJwtBearer(options =>
                {

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = conf["jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = conf["jwt:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["jwt:SecurityKey"] ?? string.Empty)),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero

                    };

                });
            return services;

        }
    }
}
