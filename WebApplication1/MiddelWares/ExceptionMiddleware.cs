using System.Net;
using System.Text.Json;
using Talabat.presentations.Errors;

namespace Talabat.presentations.MiddelWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate next,ILogger<ExceptionMiddleWare> logger,IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public  async Task InvokeAsync(HttpContext context) 
        {

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "Application/Text";
                context.Response.StatusCode= (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment() ? new ApiException(500, null, ex?.StackTrace.ToString()).ToString()
                    : new ApiException(500).ToString();
                var res = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(res);
            }
        }
    }
}
