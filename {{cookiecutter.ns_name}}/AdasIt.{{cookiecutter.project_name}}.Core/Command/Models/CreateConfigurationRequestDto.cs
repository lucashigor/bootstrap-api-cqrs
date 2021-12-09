using MediatR;

namespace AdasIt.__cookiecutter.project_name__.Core.Command.Models
{
    public class CreateConfigurationRequestModel : IRequest<CreateConfigurationResponseModel>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
