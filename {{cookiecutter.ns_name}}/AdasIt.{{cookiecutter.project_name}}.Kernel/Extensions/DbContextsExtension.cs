using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AdasIt.{{cookiecutter.project_name}}.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using AdasIt.{{cookiecutter.project_name}}.Core.Infra.Repositories;
using AdasIt.{{cookiecutter.project_name}}.Infra.Repositories;

namespace AdasIt.{{cookiecutter.project_name}}.Kernel.Extensions
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
