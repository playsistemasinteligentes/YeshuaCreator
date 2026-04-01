using Command.Interfaces.Patterns.FileStore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Patterns.FileStore
{
    public class DiskStorageProvider : IStorageProvider
    {
        public string Name => "Disk";

        private readonly StorageProviderSettings _settings;

        public DiskStorageProvider(IOptions<StorageSettings> options)
        {
            _settings = options.Value.Providers["Disk"];
        }

        private string GetFullPath(StoragePath path)
        {
            var normalized = path.Value
                .Replace('/', Path.DirectorySeparatorChar)
                .Replace('\\', Path.DirectorySeparatorChar);

            return Path.Combine(_settings.Root!, normalized);
        }

        public async Task<FileStorageResult> SaveAsync(
            Stream stream,
            StoragePath path,
            CancellationToken cancellationToken)
        {
            var fullPath = GetFullPath(path);

            var directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            using var output = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            await stream.CopyToAsync(output, cancellationToken);

            return new FileStorageResult
            {
                Path = path.Value
            };
        }

        public async Task DeleteAsync(StoragePath path, CancellationToken cancellationToken)
        {
            var fullPath = GetFullPath(path);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(StoragePath path, CancellationToken cancellationToken)
        {
            var fullPath = GetFullPath(path);
            return await Task.FromResult(File.Exists(fullPath));
        }

        public async Task<bool> HasFilesInDirectoryAsync(StoragePath path, CancellationToken cancellationToken)
        {
            var fullPath = GetFullPath(path);

            if (!Directory.Exists(fullPath))
                return false;

            return await Task.FromResult(Directory.EnumerateFiles(fullPath).Any());
        }

        public IEnumerable<StoragePath> ListFiles(StoragePath path)
        {
            var fullPath = GetFullPath(path);

            if (!Directory.Exists(fullPath))
                yield break;

            foreach (var file in Directory.GetFiles(fullPath))
            {
                var relative = Path.GetRelativePath(_settings.Root!, file)
                    .Replace('\\', '/');

                yield return new StoragePath(relative);
            }
        }

        public Stream OpenRead(StoragePath path)
        {
            var fullPath = GetFullPath(path);
            return new FileStream(fullPath, FileMode.Open, FileAccess.Read);
        }

        public Stream OpenWrite(StoragePath path)
        {
            var fullPath = GetFullPath(path);

            var directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            return new FileStream(fullPath, FileMode.Create, FileAccess.Write);
        }

        public string GetBaseUrl(StoragePath path)
        {
            var normalized = path.Value.Replace('\\', '/');
            return $"{_settings.BaseUrl}/{normalized}";
        }

        public bool DirectoryExists(StoragePath path)
        {
            var fullPath = GetFullPath(path);
            return Directory.Exists(fullPath);
        }
    }
}
