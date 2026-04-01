using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Interfaces.Patterns.FileStore;

namespace Shered.Patterns.FileStore
{
    public class StorageService : IFileStorage
    {
        private readonly StorageResolver _resolver;

        public StorageService(StorageResolver resolver)
        {
            _resolver = resolver;
        }

        public async Task<FileStorageResult> SaveAsync(
            IFormFile file,
            StoragePath path,
            CancellationToken cancellationToken)
        {
            var provider = _resolver.Resolve(path);

            using var stream = file.OpenReadStream();

            return await provider.SaveAsync(stream, path, cancellationToken);
        }

        public async Task DeleteAsync(StoragePath path, CancellationToken cancellationToken)
        {
            var provider = _resolver.Resolve(path);
            await provider.DeleteAsync(path, cancellationToken);
        }

        public async Task<bool> ExistsAsync(StoragePath path, CancellationToken cancellationToken)
        {
            var provider = _resolver.Resolve(path);
            return await provider.ExistsAsync(path, cancellationToken);
        }

        public async Task<bool> HasFilesInDirectoryAsync(StoragePath path, CancellationToken cancellationToken)
        {
            var provider = _resolver.Resolve(path);
            return await provider.HasFilesInDirectoryAsync(path, cancellationToken);
        }

        public IEnumerable<StoragePath> ListFiles(StoragePath path)
        {
            var provider = _resolver.Resolve(path);
            return provider.ListFiles(path);
        }

        public Stream OpenRead(StoragePath path)
        {
            var provider = _resolver.Resolve(path);
            return provider.OpenRead(path);
        }

        public Stream OpenWrite(StoragePath path)
        {
            var provider = _resolver.Resolve(path);
            return provider.OpenWrite(path);
        }

        public string GetBaseUrl(StoragePath path)
        {
            var provider = _resolver.Resolve(path);
            return provider.GetBaseUrl(path);
        }
        
        public bool DirectoryExists(StoragePath path)
        {
            var provider = _resolver.Resolve(path);
            return provider.DirectoryExists(path);
        }
    }
}
