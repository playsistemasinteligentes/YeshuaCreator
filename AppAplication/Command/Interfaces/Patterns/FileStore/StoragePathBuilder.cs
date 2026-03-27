using System;
using System.Collections.Generic;
using System.IO;

namespace Command.Interfaces.Patterns.FileStore
{
    public static class StoragePathBuilder
    {
        public static StoragePath Build(
             StorageLocation location,
            string tenant,
            string? idEntity,
            string fileName,
            bool useShard = false,
            string? shardSeed = null)
        {
            if (string.IsNullOrWhiteSpace(tenant))
                throw new ArgumentException("Tenant is required.", nameof(tenant));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("FileName is required.", nameof(fileName));

            var parts = new List<string>();

            parts.AddRange(SplitPath(location.Path));

            if (!string.IsNullOrWhiteSpace(tenant))
                parts.Add(tenant);

            if (!string.IsNullOrWhiteSpace(idEntity))
                parts.AddRange(SplitPath(idEntity));

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
        public static StoragePath BuildFromFullPath(StorageLocation location, string fullPath)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            if (string.IsNullOrWhiteSpace(fullPath))
                throw new ArgumentException(nameof(fullPath));

            var normalizedFullPath = fullPath
                .Replace('/', Path.DirectorySeparatorChar)
                .Replace('\\', Path.DirectorySeparatorChar);

            var normalizedBasePath = location.Path
                .Replace('/', Path.DirectorySeparatorChar)
                .Replace('\\', Path.DirectorySeparatorChar);

            if (!normalizedFullPath.StartsWith(normalizedBasePath, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("The provided path does not belong to the specified StorageLocation.");

            return new StoragePath(normalizedFullPath);
        }
        public static StoragePath Build(StorageLocation location, string relativePath)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            if (string.IsNullOrWhiteSpace(relativePath))
                throw new ArgumentException(nameof(relativePath));


            relativePath = relativePath.TrimStart('/', '\\');

            var combined = Path.Combine(location.Path, relativePath);

            return new StoragePath(combined);
        }

        private static StoragePath Build(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath))
                throw new ArgumentException("Filepath is required.", nameof(filepath));

            // Normaliza barras para o separador do sistema
            var normalized = filepath.Replace('/', Path.DirectorySeparatorChar)
                                     .Replace('\\', Path.DirectorySeparatorChar);

            return new StoragePath(normalized);
        }

        public static StoragePath AppendDirectory(StorageLocation location,StoragePath originalPath,string directoryName)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            if (originalPath == null)
                throw new ArgumentNullException(nameof(originalPath));

            if (string.IsNullOrWhiteSpace(directoryName))
                throw new ArgumentException(nameof(directoryName));

            var baseDir = originalPath.Directory;

            if (string.IsNullOrWhiteSpace(baseDir))
                throw new InvalidOperationException("StoragePath does not contain a valid directory.");

            var combined = Path.Combine(baseDir, directoryName);

            return BuildFromFullPath(location, combined);
        }

        public static StoragePath AppendFile(StorageLocation location,StoragePath originalPath,string fileName)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            if (originalPath == null)
                throw new ArgumentNullException(nameof(originalPath));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException(nameof(fileName));

            var baseDir = originalPath.Directory;

            if (string.IsNullOrWhiteSpace(baseDir))
                throw new InvalidOperationException("StoragePath does not contain a valid directory.");

            var combined = Path.Combine(baseDir, fileName);

            return BuildFromFullPath(location, combined);
        }



        private static IEnumerable<string> SplitPath(string path)
        {
            return path.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}