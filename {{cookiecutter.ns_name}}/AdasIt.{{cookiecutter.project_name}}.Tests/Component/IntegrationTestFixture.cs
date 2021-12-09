using AdasIt.__cookiecutter.project_name__.Core.Models;
using AdasIt.__cookiecutter.project_name__.Core.Models.Exceptions;
using AdasIt.__cookiecutter.project_name__.Infra.Repositories.Context;
using AdasIt.__cookiecutter.project_name__.WebApi;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace AdasIt.__cookiecutter.project_name__.Tests.Component
{
    public class IntegrationTestFixture : CustomWebApplicationFactory<Startup>
    {
        public WireMockServer WireMockServer { get; }
        private readonly string apikey = "ba64afaa614e49fca0e40153b95f2504";
        public DbContextOptions<PrincipalContext> DbContextOptions { get; }

        public IntegrationTestFixture()
        {
            if (WireMockServer == null || !WireMockServer.IsStarted)
            {
                WireMockServer = WireMockServer.Start(9999);
            }

            DbContextOptions = new DbContextOptionsBuilder<PrincipalContext>()
                .UseInMemoryDatabase("IntegrationTestDatabase")
                .Options;
        }

        public void ResetWireMock()
        {
            WireMockServer.Reset();
        }

        public HttpClient CreateAuthorizedClient()
        {
            return CreateAuthorizedClient(null, null);
        }
        public HttpClient CreateAuthorizedClient(string token)
        {
            return CreateAuthorizedClient(token, null);
        }

        public HttpClient CreateAuthorizedClient(string token, string language)
        {
            HttpClient client = CreateClient();

            client.DefaultRequestHeaders.Add("apikey", apikey);

            if (!String.IsNullOrEmpty(language))
            {
                client.DefaultRequestHeaders.Add("Accept-Language", language);
            }
            else
            {
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            }

            if (!String.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
            }

            return client;
        }


        public void ResetDatabase()
        {
            using PrincipalContext context = new (DbContextOptions);
            context.Configurations.RemoveRange(context.Configurations);
            context.SaveChanges();

            context.Configurations.AddRange(new List<Configurations>()
            { new ()
                {
                Id = Guid.NewGuid(),
                Name = "Primeira",
                Description = "Primeira Configuração",
                Value = "1"
                }
            }
            );

            context.SaveChanges();
        }

        public static IRequestBuilder CreateWiremockRequest(HttpMethod method, string path)
        {
            return CreateWiremockRequest(method, path, new Dictionary<string, string>(), null);
        }

        public static IRequestBuilder CreateWiremockRequest(HttpMethod method, string path, object body)
        {
            return CreateWiremockRequest(method, path, new Dictionary<string, string>(), body);
        }

        public static IRequestBuilder CreateWiremockRequest(HttpMethod method, string path, Dictionary<string, string> prams)
        {
            return CreateWiremockRequest(method, path, prams, null);
        }
        public static IRequestBuilder CreateWiremockRequest(HttpMethod method, string path, Dictionary<string, string> prams, object body)
        {
            IRequestBuilder requestBuilder = Request.Create();
            requestBuilder.WithPath(path);

            foreach (KeyValuePair<string, string> keyValue in prams)
            {
                requestBuilder.WithParam(keyValue.Key, keyValue.Value);
            }

            if (body != null)
            {
                var jsonBody = JsonConvert.SerializeObject(body);

                requestBuilder.WithBody(new JsonMatcher(jsonBody));
            }

            return method.Method switch
            {
                "GET" => requestBuilder.UsingGet(),
                "POST" => requestBuilder.UsingPost(),
                "PUT" => requestBuilder.UsingPut(),
                "DELETE" => requestBuilder.UsingDelete(),
                _ => requestBuilder.UsingAnyMethod()
            };
        }

        public static IResponseBuilder CreateWiremockResponse(HttpStatusCode code)
        {
            IResponseBuilder responseBuilder = Response.Create();
            responseBuilder.WithStatusCode(code);
            responseBuilder.WithHeader("Content-Type", MediaTypeNames.Application.Json);

            return responseBuilder;
        }

        public static IResponseBuilder CreateWiremockResponse(HttpStatusCode code, object body)
        {
            IResponseBuilder responseBuilder = CreateWiremockResponse(code);

            responseBuilder.WithBodyAsJson(body);

            return responseBuilder;
        }

        public void RegisterWiremockResponse(IRequestBuilder request, IResponseBuilder response)
        {
            WireMockServer
                .Given(request)
                .RespondWith(response);
        }

        public Task<T> GetWithValidations<T>(string url)
        {
            return GetWithValidations<T>(url, null, new());
        }

        public async Task<T> GetWithValidations<T>(string url, string code, List<ErrorModel> errorDetails)
        {
            HttpClient client;

            client = CreateAuthorizedClient();

            var response = await client.GetAsync(url);

            return await ValidateResponse<T>(code, errorDetails, response);
        }

        public Task<T> PostWithValidations<T>(string url, object data)
        {
            return PostWithValidations<T>(url, null, new(), data);
        }

        public async Task<T> PostWithValidations<T>(string url, string code, List<ErrorModel> errorDetails, object data)
        {
            HttpClient client;
            StringContent httpContent;

            client = CreateAuthorizedClient();

            Body(data, out httpContent);

            var response = await client.PostAsync(url, httpContent);

            return await ValidateResponse<T>(code, errorDetails, response);
        }

        private static void Body(object data, out StringContent httpContent)
        {
            string json = string.Empty;

            if (data != null)
            {
                json = JsonConvert.SerializeObject(data);
            }

            httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        }

        private static async Task<T> ValidateResponse<T>(string code, List<ErrorModel> errorDetails, HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var ret = JsonConvert.DeserializeObject<DefaultResponseDto<T>>(content);

            Assert.NotNull(ret);
            Assert.Equal(code, ret.ErrorCode);
            Assert.Equal(errorDetails, ret.Errors);

            return ret.Data;
        }

        public void MockFeatureFlag(string ret)
        {
            var response = new DefaultResponseDto<string>(ret);

            RegisterWiremockResponse(
                CreateWiremockRequest(HttpMethod.Post, "/infra/featureflags/v1/flags"),
                CreateWiremockResponse(HttpStatusCode.OK, response));
        }
    }
}
