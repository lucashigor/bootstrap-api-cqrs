using AdasIt.{{cookiecutter.project_name}}.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdasIt.{{cookiecutter.project_name}}.Tests.Component
{
    public class ConfigurationControllerTest : IClassFixture<IntegrationTestFixture>
    {
        private readonly IntegrationTestFixture _fixture;

        private const string configurationsUrl = "/configurations";

        public ConfigurationControllerTest(IntegrationTestFixture integrationTestFixture)
        {
            _fixture = integrationTestFixture;
            _fixture.ResetWireMock();
            _fixture.ResetDatabase();
        }

        [Fact]
        public async Task Get_AllConfigurations_WithSuccess()
        {
            //Arrange
            string url = $"{configurationsUrl}";

            //Test
            var ret = await _fixture.GetWithValidations<List<Configurations>>(url);

            //Asset
            Assert.Single(ret);
        }
    }
}
