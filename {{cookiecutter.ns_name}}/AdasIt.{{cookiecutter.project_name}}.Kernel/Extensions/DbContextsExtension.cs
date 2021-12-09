using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AdasIt.__cookiecutter.project_name__.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using AdasIt.__cookiecutter.project_name__.Core.Infra.Repositories;
using AdasIt.__cookiecutter.project_name__.Infra.Repositories;

namespace AdasIt.__cookiecutter.project_name__.Kernel.Extensions
{
    public static class DbContextsExtension
    {
        public static IServiceCollection AddDbContexts(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("PrincipalDatabase");

            if (!string.IsNullOrEmpty(conn))
            {
                services.AddTransient<IConfigurationsRepository, ConfigurationsRepository>();

                services.AddDbContext<PrincipalContext>(
                    options => options.UseSqlServer(conn));
            }
            return services;
        }
    }
}
