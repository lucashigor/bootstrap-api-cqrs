using AdasIt.{{cookiecutter.project_name}}.Core.Command.Models;
using AdasIt.{{cookiecutter.project_name}}.Core.Models;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Core.Infra.Repositories
{
    public interface IConfigurationsRepository
    {
        Task<Configurations> CreateConfigurationByName(CreateConfigurationRequestModel entity);
        Task<Configurations> GetConfigurationByName(string ConfigurationName);
    }
}
