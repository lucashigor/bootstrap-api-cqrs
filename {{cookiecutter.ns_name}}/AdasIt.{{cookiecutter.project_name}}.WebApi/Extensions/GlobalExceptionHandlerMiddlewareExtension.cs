using AdasIt.__cookiecutter.project_name__.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AdasIt.__cookiecutter.project_name__.WebApi.Extensions
{
    public static class GlobalExceptionHandlerMiddlewareExtension
    {
        public static IServiceCollection AddGlobalExceptionHandlerMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<GlobalExceptionHandlerMiddleware>();
        }

        public static void UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

        }
    }
}

