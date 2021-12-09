using AdasIt.__cookiecutter.project_name__.Core.Models;
using AdasIt.__cookiecutter.project_name__.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly Notifier notifier;

        public BaseController(Notifier notifier)
        {
            this.notifier = notifier;
        }

        protected IActionResult Result(object model)
        {
            var responseDto = new DefaultResponseDto<object>(model);

            if (notifier.Erros.Any())
            {
                responseDto.SetErrorCode(notifier.ErrorCode);
                responseDto.Errors.AddRange(notifier.Erros);

                return BadRequest(responseDto);
            }

            return Ok(responseDto);
        }
    }
}
