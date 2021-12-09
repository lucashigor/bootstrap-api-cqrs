using AdasIt.__cookiecutter.project_name__.Core.Command.Models;
using AdasIt.__cookiecutter.project_name__.Core.Models;
using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.Core.Infra.Repositories
{
    public interface IConfigurationsRepository
    {
        Task<Configurations> CreateConfigurationByName(CreateConfigurationRequestModel entity);
        Task<Configurations> GetConfigurationByName(string ConfigurationName);
    }
}
