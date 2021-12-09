using AdasIt.{{cookiecutter.project_name}}.Core.Command.Models;
using AdasIt.{{cookiecutter.project_name}}.Core.Infra.Repositories;
using AdasIt.{{cookiecutter.project_name}}.Core.Models;
using AdasIt.{{cookiecutter.project_name}}.Infra.Repositories.Context;
using System.Linq;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Infra.Repositories
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly PrincipalContext principalContext;

        public ConfigurationsRepository(PrincipalContext principalContext)
        {
            this.principalContext = principalContext;
        }

        public Task<Configurations> GetConfigurationByName(string ConfigurationName)
        {
            Core.Models.Configurations responseDto = null;

            responseDto = principalContext.Configurations.FirstOrDefault(x => x.Name.Equals(ConfigurationName));

            return Task.FromResult(responseDto);
        }

        public Task<Configurations> CreateConfigurationByName(CreateConfigurationRequestModel entity)
        {
            var responseDto = new Configurations()
            {
                Name = entity.Name,
                Value = entity.Value,
                Description = entity.Description
            };

            principalContext.Configurations.Add(responseDto);

            principalContext.SaveChanges();

            return Task.FromResult(responseDto);
        }
    }
}
