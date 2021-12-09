using MediatR;

namespace AdasIt.{{cookiecutter.project_name}}.Core.Command.Models
{
    public class CreateConfigurationRequestModel : IRequest<CreateConfigurationResponseModel>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
