using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdasIt.{{cookiecutter.project_name}}.Kernel.Extensions
{
    public static class AutoMapperProfilesExtension
    {
        public static IServiceCollection AddAutoMapperProfiles(
            this IServiceCollection services,
            params Type[] additionalMappers)
        {
            List<Type> mappers = additionalMappers.ToList();

            services.AddAutoMapper(mappers.ToArray());
            return services;
        }
    }
}
