using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using System.Text.Json;
using Talabat.Access.Models;
using Talabat.Access.Models.Company;
using Talabat.Core.Interfaces.Repository;
using Talabat.presentations.Errors;
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
            var WebApplicationBuilder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            WebApplicationBuilder.Services.AddEndpointsApiExplorer();
            WebApplicationBuilder.Services.AddDbContext<StoreDbContext>(option =>
            {

                option.UseSqlServer(WebApplicationBuilder.Configuration.GetConnectionString("Default"));
            });
            WebApplicationBuilder.Services.AddDbContext<CompanyDbContext>(option =>
            {
                option.UseSqlServer(WebApplicationBuilder.Configuration.GetConnectionString("Company"));

            });





            // Add Services Function
            WebApplicationBuilder.Services.AddSevices(WebApplicationBuilder.Configuration);

            
            var app = WebApplicationBuilder.Build();
            await AutoMigrateAsync(app);

            

            // Configure the HTTP request pipeline.
            // Expetion MiddleWare

            // exception meddleware must be first middleware
            //
            // By-Convension/By-Factory
            //app.UseMiddleware<ExceptionMiddleware>();
            
            //Request Delegate
            app.Use(async (httpContext, _next) => {

                try
                {
                    await _next.Invoke(httpContext);
                }
                catch (Exception ex)
                {
                    {
                        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        httpContext.Response.ContentType = "application/json";
                        var response = app.Environment.IsDevelopment() ? new ApiException(httpContext.Response.StatusCode, ex.Message
                            , ex.StackTrace.ToString()) :
                            new ApiException();
                        // determind json serializer options
                        var option = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, option));


                    }



                }
            });



            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("Errors/{0}");
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.MapControllers();



            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }

        private static async Task AutoMigrateAsync(WebApplication app)
        {
            var scoop = app.Services.CreateScope();
            var servies = scoop.ServiceProvider;
            var context = servies.GetRequiredService<StoreDbContext>();
            var CompanyContext = servies.GetRequiredService<CompanyDbContext>();
            var Ilogger = servies.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
                await CompanyContext.Database.MigrateAsync();
                await Data.ReadAsync(context);
            }
            catch (Exception ex)
            {
                var logger = Ilogger.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);

                throw;
            }
        }
    }
}
