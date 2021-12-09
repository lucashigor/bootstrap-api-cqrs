using AdasIt.{{cookiecutter.project_name}}.Core.Models;
using AdasIt.{{cookiecutter.project_name}}.Infra.Services.FeatureFlag.Request;
using Refit;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Infra.Services.FeatureFlag
{
    public interface IFeatureFlagClient
    {
        [Post("/flags")]
        Task<DefaultResponseDto<string>> Flags([Body] RequestDto autenticacaoRequestDto);
    }
}
