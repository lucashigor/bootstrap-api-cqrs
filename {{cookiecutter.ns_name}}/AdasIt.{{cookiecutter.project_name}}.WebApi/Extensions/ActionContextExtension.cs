using AdasIt.{{cookiecutter.project_name}}.Core.Constants;
using AdasIt.{{cookiecutter.project_name}}.Core.Models;
using AdasIt.{{cookiecutter.project_name}}.Core.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdasIt.{{cookiecutter.project_name}}.WebApi.Extensions
{
    public static class ActionContextExtension
    {
        public static BadRequestObjectResult GetErrorsModelState(this ActionContext actionContext)
        {
            return new BadRequestObjectResult(
                new DefaultResponseDto<object>(null, 
                                               ErrorCodeConstant.Validation.Code,
                                               actionContext.ModelState.Values.Where(v => v.Errors.Count > 0)
                                                    .SelectMany(v => v.Errors)
                                                    .Select(v => new ErrorModel(ErrorCodeConstant.Validation.Code, v.ErrorMessage))
                                                    .ToList()
                                                )
                );
        }
    }
}
