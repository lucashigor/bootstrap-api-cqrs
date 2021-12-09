using AdasIt.__cookiecutter.project_name__.Core.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace AdasIt.__cookiecutter.project_name__.Kernel.Extensions
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
