using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public sealed class AuthenticationAttribute : Attribute, IAsyncAuthorizationFilter, IAuthorizationFilter, IOrderedFilter
    {
        private readonly string authenticationScheme = "apiKey";

        private readonly List<string> key = new();

        int IOrderedFilter.Order => 0;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            OnAuthorizationAsync(context).Wait();
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var req = context.HttpContext.Request;

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (env != "Development")
            {
                var listKey = Environment.GetEnvironmentVariable("ListOfAllowedAPIKeys");

                key.AddRange(listKey.Split(';'));

                string value = req.Headers[authenticationScheme];

                if (String.IsNullOrEmpty(value) || !key.Contains(value.ToLower()))
                {
                    context.Result = new UnauthorizedResult();
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.HttpContext.Response.WriteAsync("{\"success\": false,\"data\": null}");
                }
            }
        }
    }
}
