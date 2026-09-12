using Microsoft.Extensions.Caching.Memory;
using RepositoryInterfaces.Services;
using System.Collections.Concurrent;

namespace Shered.Services
{
    public class MemoryCacheService<T> : ICacheService<T>
    {
        private readonly IMemoryCache _cache;
        private readonly ICacheKeyIndexManager _indexManager;

        public MemoryCacheService(IMemoryCache cache, ICacheKeyIndexManager indexManager)
        {
            _cache = cache;
            _indexManager = indexManager;
        }

        public T Get(string key)
        {
            _cache.TryGetValue(key, out T value);
            return value!;
        }

        public void Set(string key, T value, string prefix, TimeSpan? expiration = null)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(10),
                PostEvictionCallbacks =
            {
                new PostEvictionCallbackRegistration
                {
                    EvictionCallback = (k, _, _, _) =>
                        _indexManager.RemoveKey(prefix, k.ToString())
                }
            }
            };

            _cache.Set(key, value, options);
            _indexManager.AddKey(prefix, key);
        }

        public void Remove(string key, string prefix)
        {
            _cache.Remove(key);
            _indexManager.RemoveKey(prefix, key);
        }

        public void RemoveByPrefix(string prefix)
        {
            foreach (var key in _indexManager.GetKeys(prefix))
            {
                _cache.Remove(key);
            }

            _indexManager.RemoveAll(prefix);
        }
    }
}
