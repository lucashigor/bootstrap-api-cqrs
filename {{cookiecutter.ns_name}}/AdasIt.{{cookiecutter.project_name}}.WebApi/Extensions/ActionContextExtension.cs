using AdasIt.__cookiecutter.project_name__.Core.Constants;
using AdasIt.__cookiecutter.project_name__.Core.Models;
using AdasIt.__cookiecutter.project_name__.Core.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdasIt.__cookiecutter.project_name__.WebApi.Extensions
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
