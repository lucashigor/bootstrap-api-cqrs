using AdasIt.__cookiecutter.project_name__.Core.Command.Models;
using AdasIt.__cookiecutter.project_name__.Core.Infra.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.Core.Command.Handlers
{
    public class ConfigurationCommandHandler : IRequestHandler<CreateConfigurationRequestModel, CreateConfigurationResponseModel>
    {
        private readonly IConfigurationsRepository configurationsRepository;

        public ConfigurationCommandHandler(IConfigurationsRepository configurationsRepository)
        {
            this.configurationsRepository = configurationsRepository;
        }

        public async Task<CreateConfigurationResponseModel> Handle(CreateConfigurationRequestModel request, CancellationToken cancellationToken)
        {
            var ret = await configurationsRepository.CreateConfigurationByName(request);

            return new CreateConfigurationResponseModel()
            {
                Description = ret.Description,
                Name = ret.Name,
                Value = ret.Value
            };
        }
    }
}
