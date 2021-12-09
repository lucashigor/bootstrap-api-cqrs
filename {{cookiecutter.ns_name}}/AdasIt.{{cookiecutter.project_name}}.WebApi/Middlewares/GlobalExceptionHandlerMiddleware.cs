using AdasIt.{{cookiecutter.project_name}}.Core.Constants;
using AdasIt.{{cookiecutter.project_name}}.Core.Models;
using AdasIt.{{cookiecutter.project_name}}.Core.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.WebApi.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, $"A processing error occurred | {context.Request.Path.Value}");
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unexpected error has occurred | {context.Request.Path.Value}");
                await HandleExceptionAsync(context);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, BusinessException exception)
        {
            return HandleErrorResponseAsync(context,
                exception.StatusCode,
                exception.ContentType,
                exception.ErrorCode,
                exception.Error);
        }

        private static Task HandleExceptionAsync(HttpContext context)
        {
            return HandleErrorResponseAsync(context,
                HttpStatusCode.InternalServerError,
                MediaTypeNames.Application.Json,
                ErrorCodeConstant.Generic.Code,
                ErrorCodeConstant.Generic);
        }

        private static Task HandleErrorResponseAsync(
            HttpContext context,
            HttpStatusCode httpStatusCode,
            string mediaType,
            string errorCode,
            ErrorModel errors)
        {
            int statusCode = (int)httpStatusCode;
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = mediaType;

            var response = new DefaultResponseDto<object>(null, errorCode, errors);

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}