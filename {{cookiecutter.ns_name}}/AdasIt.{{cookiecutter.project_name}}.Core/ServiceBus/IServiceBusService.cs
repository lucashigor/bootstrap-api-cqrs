using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Core.ServiceBus
{
    public interface IServiceBusService
    {
        Task SendMessageToTopicAsync(string topicName, object entity);
    }
}
