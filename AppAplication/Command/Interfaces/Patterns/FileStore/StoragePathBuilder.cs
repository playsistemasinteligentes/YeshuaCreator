using System;
using System.Collections.Generic;
using System.IO;

namespace Command.Interfaces.Patterns.FileStore
{
    public static class StoragePathBuilder
    {
        public static StoragePath Build(
            string tenant,
            string? pathParts,
            string fileName,
            bool useShard = false,
            string? shardSeed = null)
        {
            if (string.IsNullOrWhiteSpace(tenant))
                throw new ArgumentException("Tenant is required.", nameof(tenant));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("FileName is required.", nameof(fileName));

            var parts = new List<string> { tenant };

            // Se houver pathParts, adiciona como segmento limpo
            if (!string.IsNullOrWhiteSpace(pathParts))
            {
                var splitParts = pathParts.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
                parts.AddRange(splitParts);
            }

            // Adiciona shards se necessário
            if (useShard)
            {
                var seed = shardSeed ?? Guid.NewGuid().ToString("N");
                var shard1 = seed.Substring(0, 2);
                var shard2 = seed.Substring(2, 2);
                parts.Add(shard1);
                parts.Add(shard2);
            }

            parts.Add(fileName);

            // Combina todos os segmentos
            var combinedPath = Path.Combine(parts.ToArray());

            // Normaliza barras para o separador do sistema
            combinedPath = combinedPath.Replace('/', Path.DirectorySeparatorChar)
                                       .Replace('\\', Path.DirectorySeparatorChar);

            return new StoragePath(combinedPath);
        }

        public static StoragePath Build(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath))
                throw new ArgumentException("Filepath is required.", nameof(filepath));

            // Normaliza barras para o separador do sistema
            var normalized = filepath.Replace('/', Path.DirectorySeparatorChar)
                                     .Replace('\\', Path.DirectorySeparatorChar);

            return new StoragePath(normalized);
        }
    }
}