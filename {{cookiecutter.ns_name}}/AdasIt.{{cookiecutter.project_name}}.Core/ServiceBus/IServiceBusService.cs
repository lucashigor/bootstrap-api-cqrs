using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.Core.ServiceBus
{
    public interface IServiceBusService
    {
        Task SendMessageToTopicAsync(string topicName, object entity);
    }
}
