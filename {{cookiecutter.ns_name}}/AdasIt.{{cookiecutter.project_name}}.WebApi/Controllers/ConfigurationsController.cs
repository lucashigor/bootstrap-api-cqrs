using AdasIt.{{cookiecutter.project_name}}.Core.Command.Models;
using AdasIt.{{cookiecutter.project_name}}.Core.Models;
using AdasIt.{{cookiecutter.project_name}}.Core.Notifications;
using AdasIt.{{cookiecutter.project_name}}.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authentication]
    public class ConfigurationsController : BaseController
    {
        private readonly IMediator mediator;

        public ConfigurationsController(Notifier notifier,
             IMediator mediator) : base(notifier)
        {
            this.mediator = mediator;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> CreateConfigurations([FromBody] CreateConfigurationRequestModel entity)
        {
            var response = await mediator.Send(entity);

            return Result(response);
        }

        [HttpGet, Route("")]
        public Task<IActionResult> GetListConfigurations()
        {
            var config = new List<Configurations>() {
                new () { Id = System.Guid.NewGuid() }};

            return Task.FromResult(Result(config));
        }
    }
}
