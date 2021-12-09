using AdasIt.{{cookiecutter.project_name}}.Core.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace AdasIt.{{cookiecutter.project_name}}.WebApi.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Adas IT Boostrap API",
                        Version = "v1",
                        Description = "Bootstrap Api CQRS",
                        Contact = new OpenApiContact()
                        {
                            Name = "Adas It",
                            Url = new Uri(AppConstants.CompanyWebSite)
                        }
                    });

                c.AddSecurityDefinition("apiKey", new OpenApiSecurityScheme
                {
                    Name = "apiKey",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "apiKey"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                        Id = "apiKey"
                        },
                        Scheme = "apiKey",
                        Name = "apiKey",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
