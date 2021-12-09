using AdasIt.{{cookiecutter.project_name}}.Core.Command.Handlers;
using AdasIt.{{cookiecutter.project_name}}.Kernel.Extensions;
using AdasIt.{{cookiecutter.project_name}}.WebApi.Extensions;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using System;
using System.Reflection;

namespace AdasIt.{{cookiecutter.project_name}}.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var conf = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json");

            if (env != "Test" 
                && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("KeyVaultVault"))
                && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("KeyVaultClientId"))
                && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("KeyVaultClientSecret")))
            {
                conf.AddAzureKeyVault($"{Environment.GetEnvironmentVariable("KeyVaultVault")}", Environment.GetEnvironmentVariable("KeyVaultClientId"), Environment.GetEnvironmentVariable("KeyVaultClientSecret"));
            }

            Configuration = conf.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwagger()
                .AddAutoMapperProfiles()
                .AddGlobalExceptionHandlerMiddleware()
                .AddDbContexts(Configuration)
                .AddHttpClients(Configuration)
                .AddUseCases()
                .AddServices(Configuration)
                .AddControllers()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                })
                .AddNewtonsoftJson(opts => opts.SerializerSettings.Converters.Add(new StringEnumConverter()))
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);

            services.AddMediatR(typeof(ConfigurationCommandHandler));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            string instrumentationKey = Configuration["InstrumentationKey"];

            if (!string.IsNullOrEmpty(instrumentationKey))
            {
                services.AddApplicationInsightsTelemetry(Configuration);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdasIt.{{cookiecutter.project_name}}.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
