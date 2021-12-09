using AdasIt.{{cookiecutter.project_name}}.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AdasIt.{{cookiecutter.project_name}}.WebApi.Extensions
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

