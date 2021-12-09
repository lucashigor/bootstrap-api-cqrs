using AdasIt.{{cookiecutter.project_name}}.Core.ServiceBus;
using AdasIt.{{cookiecutter.project_name}}.Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdasIt.{{cookiecutter.project_name}}.Kernel.Extensions
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
