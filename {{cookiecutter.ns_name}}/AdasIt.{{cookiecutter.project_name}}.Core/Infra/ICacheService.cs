using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Core.Infra
{
    public interface ICacheService
    {
        Task<string> GetCache(string key);
        Task<T> GetCache<T>(string key) where T : class;
        Task KeyDelete(string key);
        Task SetCache(string key, object entity);
    }
}