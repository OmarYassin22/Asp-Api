using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Talabat.presentations.Errors;

namespace Talabat.presentations.MiddelWares
{
    public class ExceptionMiddleware : IMiddleware
    {
        //private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(/*RequestDelegate next,*/ ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            //_next = next;
            _logger = logger;
            _env = env;
        }
        //By-Coonviension
   /*     public async Task InvokeAsync(HttpContext httpContext)
        {


            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    var response = _env.IsDevelopment() ? new ApiException(httpContext.Response.StatusCode, ex.Message
                        , ex.StackTrace.ToString()) :
                        new ApiException();
                    // determind json serializer options
                    var option = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, option));


                }



            }
        }
*/
     
        // By Factory
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate _next)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    var response = _env.IsDevelopment() ? new ApiException(httpContext.Response.StatusCode, ex.Message
                        , ex.StackTrace.ToString()) :
                        new ApiException();
                    // determind json serializer options
                    var option = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, option));


                }



            }
        }
    }
}
