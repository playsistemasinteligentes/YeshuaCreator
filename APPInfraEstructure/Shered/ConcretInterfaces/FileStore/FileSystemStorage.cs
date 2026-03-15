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

        public async Task<FileStorageResult> SaveAsync(IFormFile file, StoragePath path, CancellationToken cancellationToken)
        {
            var fullPath = Path.Combine(_rootPath, path.Value);

            var directory = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            await using (var fileStream = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write, FileShare.None, 81920, true))
            {
                await file.CopyToAsync(fileStream, cancellationToken);
            }

            var fileInfo = new FileInfo(fullPath);

            if (!fileInfo.Exists || fileInfo.Length == 0)
            {
                File.Delete(fullPath);
                throw new IOException("Arquivo salvo inválido (0 bytes).");
            }

            var relativePath = Path.Combine(path.Value);

            return new FileStorageResult
            {
                Path = relativePath.Replace("\\", "/"),
                Size = fileInfo.Length
            };
        }

        public Task DeleteAsync(StoragePath path, CancellationToken cancellationToken)
        {
            var fullPath = Path.Combine(_rootPath, path.Value);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(StoragePath path, CancellationToken cancellationToken)
        {
            var fullPath = Path.Combine(_rootPath, path.Value);

            return Task.FromResult(File.Exists(fullPath));
        }
    }
}
