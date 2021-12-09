using AdasIt.__cookiecutter.project_name__.Infra.Services.FeatureFlag;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace AdasIt.__cookiecutter.project_name__.Kernel.Extensions
{
    public static class HttpClientsExtension
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var url = new Uri(configuration["url-gateway"]);

            string subscriptionKey = configuration["subscription-key"];

            string featureFlagBaseUrl = configuration["FeatureFlagIntegration:Url"];

            services
                .AddRefitClient<IFeatureFlagClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(url, featureFlagBaseUrl))
                .ConfigureHttpClient(c => c.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey));

            return services;
        }
    }
}
