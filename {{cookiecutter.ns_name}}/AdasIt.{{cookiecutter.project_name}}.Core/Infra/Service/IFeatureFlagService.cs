using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Core.Infra.Service
{
    public interface IFeatureFlagService
    {
        Task<string> GetValueAsync(string key, string feature, Dictionary<string, string> att);
        Task<string> GetValueAsync(string key, string feature);
        Task<bool> IsEnabledAsync(string feature);
        Task<bool> IsEnabledAsync(string key, string feature);
        Task<bool> IsEnabledAsync(string key, string feature, Dictionary<string, string> att);
    }
}
