using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Interfaces.Patterns.FileStore;
using Microsoft.Extensions.Options;


namespace Shered.Patterns.FileStore
{
    public class StorageResolver
    {
        private readonly StorageSettings _settings;
        private readonly Dictionary<string, IStorageProvider> _providers;

        public StorageResolver(
            IOptions<StorageSettings> settings,
            IEnumerable<IStorageProvider> providers)
        {
            _settings = settings.Value;
            _providers = providers.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
        }

        public IStorageProvider Resolve(StoragePath path)
        {
            var normalizedPath = path.Value.Replace('\\', '/');

            var location = _settings.Locations
                .OrderByDescending(l => l.Key.Length)
                .FirstOrDefault(l => normalizedPath.StartsWith(l.Key, StringComparison.OrdinalIgnoreCase));

            if (location.Key == null)
                throw new Exception($"No storage location configured for path: {path.Value}");

            var providerName = location.Value;

            if (!_providers.TryGetValue(providerName, out var provider))
                throw new Exception($"Storage provider '{providerName}' not registered.");

            return provider;
        }
    }
}
