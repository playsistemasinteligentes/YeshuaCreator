using RepositoryInterfaces.Services;
using System.Collections.Concurrent;

namespace Shered.Services
{

    public class CacheKeyIndexManager : ICacheKeyIndexManager
    {
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, byte>> _index
            = new();

        public void AddKey(string prefix, string key)
        {
            var keys = _index.GetOrAdd(prefix, _ => new ConcurrentDictionary<string, byte>());
            keys.TryAdd(key, 0);
        }

        public void RemoveKey(string prefix, string key)
        {
            if (_index.TryGetValue(prefix, out var keys))
            {
                keys.TryRemove(key, out _);
                if (keys.IsEmpty)
                    _index.TryRemove(prefix, out _);
            }
        }

        public IEnumerable<string> GetKeys(string prefix)
        {
            if (_index.TryGetValue(prefix, out var keys))
                return keys.Keys;

            return Enumerable.Empty<string>();
        }

        public void RemoveAll(string prefix)
        {
            _index.TryRemove(prefix, out _);
        }
    }

}
