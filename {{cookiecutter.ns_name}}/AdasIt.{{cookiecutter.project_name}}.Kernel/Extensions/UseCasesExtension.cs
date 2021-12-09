using AdasIt.{{cookiecutter.project_name}}.Core.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace AdasIt.{{cookiecutter.project_name}}.Kernel.Extensions
{
    public static class UseCasesExtension
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Notifier>(x => new Notifier());

            return services;
        }
    }
}
