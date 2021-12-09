using AdasIt.__cookiecutter.project_name__.Core.Infra;
using StackExchange.Redis;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdasIt.__cookiecutter.project_name__.Infra.CacheService
{
    [ExcludeFromCodeCoverage]
    public class CacheService : ICacheService
    {
        private readonly IDatabase cache;
        public CacheService(IRedisConnection redisCache)
        {
            this.cache = redisCache.GetDatabase();
        }

        public async Task<string> GetCache(string key)
        {
            string ret = null;

            var stringCache = await cache.StringGetAsync(key);

            if (stringCache.HasValue)
            {
                return stringCache;
            }

            return ret;
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


        public async Task SetCache(string key, object entity)
        {
            var obj = JsonSerializer.Serialize(entity);

            await cache.StringSetAsync(key, obj, TimeSpan.FromHours(6));
        }

        public async Task KeyDelete(string key)
        {
            await cache.KeyDeleteAsync(key);
        }
    }
}
