using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using Talabat.Access.Models;
using Talabat.Access.Models.Company;
using Talabat.Core.Interfaces.Repository;
using Talabat.presentations.Extentions;
using Talabat.presentations.Helpers;
using Talabat.presentations.MiddelWares;
using Talabat.Repo.Data.Contexts;
using Talabat.Repo.Repositories;
using Talabat.Repos.Data.Contexts;
using Talabat.Repos.Helpers;
using Talabat.Repos.Repositories;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var WebBuilder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            WebBuilder.Services.AddDbContext<StoreDbContext>(option =>
            {

                option.UseSqlServer(WebBuilder.Configuration.GetConnectionString("Default"));
            });
            WebBuilder.Services.AddDbContext<CompanyDbContext>(option =>
            {
                option.UseSqlServer(WebBuilder.Configuration.GetConnectionString("Company"));

            });

            WebBuilder.Services.AddSevices();
            WebBuilder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfile(WebBuilder.Configuration)));


            var app = WebBuilder.Build();
            var scoop = app.Services.CreateScope();
            var servies = scoop.ServiceProvider;
            var context = servies.GetRequiredService<StoreDbContext>();
            var conmapnycontext = servies.GetRequiredService<CompanyDbContext>();
            var Ilogger = servies.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
                await conmapnycontext.Database.MigrateAsync();
                await Data.ReadAsync(context);
            }
            catch (Exception ex)
            {
                var logger = Ilogger.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);

                throw;
            }



            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionMiddleWare>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithRedirects("Errors/{0}");
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            
            app.MapControllers();
        


            app.UseAuthentication();
            app.UseAuthorization();
           
            app.Run();
        }
    }
}
