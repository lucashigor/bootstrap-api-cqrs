using AdasIt.{{cookiecutter.project_name}}.Core.Infra;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Tests.Utils
{
    public class CacheServiceTest : ICacheService
    {
        private readonly IMemoryCache cache;
        public CacheServiceTest()
        {
            this.cache = new MyMemoryCache().Cache;
        }

        public async Task<T> GetCache<T>(string key) where T : class
        {
            T responseDto = null;

            var retChache = await GetCache(key);

            if (retChache != null)
            {
                try
                {
                    responseDto = JsonSerializer.Deserialize<T>(retChache);
                }
                catch (Exception)
                {
                    responseDto = null;

                    await KeyDelete(key);
                }
            }

            return responseDto;
        }

        public Task<string> GetCache(string key)
        {
            cache.TryGetValue(key, out string ret);

            return Task.FromResult(ret);
        }

        public Task SetCache(string key, object entity)
        {
            var responseDto = JsonSerializer.Serialize(entity);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(3)).SetSize(1);

            cache.Set(key, responseDto, cacheEntryOptions);

            return Task.CompletedTask;
        }

        public Task KeyDelete(string key)
        {
            cache.Remove(key);

            return Task.CompletedTask;
        }
    }
}