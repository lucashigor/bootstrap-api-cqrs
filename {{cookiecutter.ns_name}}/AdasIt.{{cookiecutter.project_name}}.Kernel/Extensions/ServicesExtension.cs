using AdasIt.__cookiecutter.project_name__.Core.ServiceBus;
using AdasIt.__cookiecutter.project_name__.Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdasIt.__cookiecutter.project_name__.Kernel.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IServiceBusService>(x => new ServiceBusService(configuration));

            return services;
        }
    }
}
