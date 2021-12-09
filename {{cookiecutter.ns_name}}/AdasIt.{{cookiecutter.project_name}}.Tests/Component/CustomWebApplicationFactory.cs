using AdasIt.{{cookiecutter.project_name}}.Core.Infra;
using AdasIt.{{cookiecutter.project_name}}.Core.ServiceBus;
using AdasIt.{{cookiecutter.project_name}}.Infra.Repositories.Context;
using AdasIt.{{cookiecutter.project_name}}.Tests.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace AdasIt.{{cookiecutter.project_name}}.Tests.Component
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder()
                .UseEnvironment("Test");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
            Environment.SetEnvironmentVariable("ListOfAllowedAPIKeys", "ba64afaa614e49fca0e40153b95f2504");

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<PrincipalContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<PrincipalContext>(options =>
                {
                    options.UseInMemoryDatabase("IntegrationTestDatabase");
                });


                var descriptorCache = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(ICacheService));

                var descriptorService = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(IServiceBusService));

                if (descriptorCache != null)
                {
                    services.Remove(descriptorCache);
                }

                if (descriptorService != null)
                {
                    services.Remove(descriptorService);
                }

                services.AddSingleton<ICacheService, CacheServiceTest>();
                services.AddSingleton<IServiceBusService, ServiceBusServiceTest>();

                var sp = services.BuildServiceProvider();

                // Create scope for db initialization
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<PrincipalContext>();
                db.Database.EnsureCreated();
            });
        }
    }
}
