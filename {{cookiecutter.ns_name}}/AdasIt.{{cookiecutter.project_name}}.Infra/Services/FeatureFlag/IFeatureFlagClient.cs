using AdasIt.__cookiecutter.project_name__.Core.Models;
using AdasIt.__cookiecutter.project_name__.Infra.Services.FeatureFlag.Request;
using Refit;
using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.Infra.Services.FeatureFlag
{
    public interface IFeatureFlagClient
    {
        [Post("/flags")]
        Task<DefaultResponseDto<string>> Flags([Body] RequestDto autenticacaoRequestDto);
    }
}
