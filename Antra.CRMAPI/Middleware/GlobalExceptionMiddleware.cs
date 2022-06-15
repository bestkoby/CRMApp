using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Antra.CRMAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public GlobalExceptionMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _loggerFactory = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Log.Information("Logger start");
            try 
            {
                await _next(httpContext);  
            } catch (Exception ex) 
            {
                Log.Error(ex, "Exception has been handled");
                //var _logger = _loggerFactory.CreateLogger<GlobalExceptionMiddleware>();
                //_logger.LogError(ex.StackTrace);
                await httpContext.Response.WriteAsync(ex.Message);
            }
            finally
            {
                Log.CloseAndFlush();
            }
            //var ex = httpContext.Features.Get<IExceptionHandlerFeature>();
            //if (ex != null)
            //{
            //    await httpContext.Response.WriteAsync(ex.Error.Message);
            //}
            //await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
