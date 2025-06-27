using Microsoft.Extensions.Caching.Memory;
using RepositoryInterfaces.Services;

namespace Shered.Services
{

    public class MemoryCacheService<T> : ICacheService<T>
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T Get(string key)
        {
            _cache.TryGetValue(key, out T value);
            return value;
        }

        public void Set(string key, T value, TimeSpan? expiration = null)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(10)
            };
            _cache.Set(key, value, options);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
