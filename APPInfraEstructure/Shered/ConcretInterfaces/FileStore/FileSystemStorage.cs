using Command.Interfaces.Patterns.FileStore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shered.ConcretInterfaces.FileStore
{

    public class FileSystemStorage : IFileStorage
    {
        private readonly string _rootPath;

        public FileSystemStorage(IOptions<FileSystemOptions> options)
        {
            _rootPath = options.Value.RootPath;
            Directory.CreateDirectory(_rootPath);
        }

        public async Task<FileStorageResult> SaveAsync(
            IFormFile stream,
            string fileName,
            FileSaveOptions options,
            CancellationToken cancellationToken)
        {
            // GUID usado para nome e sharding
            var guid = Guid.NewGuid().ToString("N");

            var shard1 = guid[..2];
            var shard2 = guid.Substring(2, 2);

            var safeFileName = $"{guid}_{Path.GetFileName(fileName)}";

            var parts = new List<string>
        {
            _rootPath,
            options.Tenant,
            options.Storage.Value
        };

            if (!string.IsNullOrWhiteSpace(options.Prefix))
                parts.Add(options.Prefix);

            parts.Add(shard1);
            parts.Add(shard2);

            var folder = Path.Combine(parts.ToArray());

            Directory.CreateDirectory(folder);

            var fullPath = Path.Combine(folder, safeFileName);

            await using var fileStream = new FileStream(
                fullPath,
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None,
                81920,
                true);

            await stream.CopyToAsync(fileStream, cancellationToken);

            var fileInfo = new FileInfo(fullPath);

            if (!fileInfo.Exists || fileInfo.Length == 0)
            {
                File.Delete(fullPath);
                throw new IOException("Arquivo salvo inválido (0 bytes).");
            }

            var relativeParts = new List<string>
        {
            options.Tenant,
            options.Storage.Value
        };

            if (!string.IsNullOrWhiteSpace(options.Prefix))
                relativeParts.Add(options.Prefix);

            relativeParts.Add(shard1);
            relativeParts.Add(shard2);
            relativeParts.Add(safeFileName);

            var relativePath = Path.Combine(relativeParts.ToArray());

            return new FileStorageResult
            {
                Path = relativePath.Replace("\\", "/"),
                Size = fileInfo.Length
            };
        }

        public Task DeleteAsync(string path, CancellationToken cancellationToken)
        {
            var fullPath = Path.Combine(_rootPath, path);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(string path, CancellationToken cancellationToken)
        {
            var fullPath = Path.Combine(_rootPath, path);

            return Task.FromResult(File.Exists(fullPath));
        }
    }
}
