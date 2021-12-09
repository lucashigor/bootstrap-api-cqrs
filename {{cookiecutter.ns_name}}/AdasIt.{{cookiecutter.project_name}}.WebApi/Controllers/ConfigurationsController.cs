using AdasIt.__cookiecutter.project_name__.Core.Command.Models;
using AdasIt.__cookiecutter.project_name__.Core.Models;
using AdasIt.__cookiecutter.project_name__.Core.Notifications;
using AdasIt.__cookiecutter.project_name__.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.WebApi.Controllers
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
