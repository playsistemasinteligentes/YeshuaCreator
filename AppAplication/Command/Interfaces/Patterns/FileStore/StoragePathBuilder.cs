using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.FileStore
{
    public static class StoragePathBuilder
    {
        public static StoragePath Build(
            string tenant,
            string? prefix,
            string fileName,
            bool useShard = false,
            string? shardSeed = null)
        {
            if (string.IsNullOrWhiteSpace(tenant))
                throw new ArgumentException("Tenant is required.", nameof(tenant));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("FileName is required.", nameof(fileName));

            var parts = new List<string> { tenant };

            if (!string.IsNullOrWhiteSpace(prefix))
                parts.Add(prefix);

            if (useShard)
            {
                var seed = shardSeed ?? Guid.NewGuid().ToString("N");

                var shard1 = seed[..2];
                var shard2 = seed.Substring(2, 2);

                parts.Add(shard1);
                parts.Add(shard2);
            }

            parts.Add(fileName);

            var path = Path.Combine(parts.ToArray());

            return new StoragePath(path);
        }
    }
}

