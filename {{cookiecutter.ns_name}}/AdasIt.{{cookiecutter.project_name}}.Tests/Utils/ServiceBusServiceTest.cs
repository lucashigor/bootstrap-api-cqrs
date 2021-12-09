using AdasIt.__cookiecutter.project_name__.Core.ServiceBus;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.Tests.Utils
{
    public class ServiceBusServiceTest : IServiceBusService
    {
        public static Dictionary<string, string> list;

        public ServiceBusServiceTest()
        {
            list = new ();
        }

        public Task SendMessageToTopicAsync(string topicName, object entity)
        {
            list.Add(topicName, JsonSerializer.Serialize(entity));
            return Task.CompletedTask;
        }
    }
}
