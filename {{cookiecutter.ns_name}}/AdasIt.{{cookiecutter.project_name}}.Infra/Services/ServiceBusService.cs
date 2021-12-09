using AdasIt.{{cookiecutter.project_name}}.Core.ServiceBus;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Infra.Services
{
    [ExcludeFromCodeCoverage]
    public class ServiceBusService : IServiceBusService
    {
        private readonly string connectionString;
        public ServiceBusService(IConfiguration configuration)
        {
            this.connectionString = configuration["serviceBusSender"];
        }

        public async Task SendMessageToTopicAsync(string topicName, object entity)
        {
            await using ServiceBusClient client = new (connectionString);
            ServiceBusSender sender = client.CreateSender(topicName);
            await sender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(entity)));
        }
    }
}
