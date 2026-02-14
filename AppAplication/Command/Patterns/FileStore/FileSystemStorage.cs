using Command.Interfaces.Patterns.FileStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Patterns.FileStore
{
    public class FileSystemStorage : IFileStorage
    {
        private readonly string _rootPath;

        public FileSystemStorage(string rootPath)
        {
            _rootPath = rootPath;
            Directory.CreateDirectory(_rootPath);
        }

        public async Task<FileStorageResult> SaveAsync(
            Stream stream,
            string fileName,
            CancellationToken cancellationToken)
        {
            var safeFileName = $"{Guid.NewGuid()}_{Path.GetFileName(fileName)}";
            var fullPath = Path.Combine(_rootPath, safeFileName);

            await using var fileStream = new FileStream(
                fullPath,
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None,
                81920,
                true);

            await stream.CopyToAsync(fileStream, cancellationToken);
            await fileStream.FlushAsync(cancellationToken);

            var fileInfo = new FileInfo(fullPath);

            if (!fileInfo.Exists || fileInfo.Length == 0)
            {
                File.Delete(fullPath);
                throw new IOException("Arquivo salvo inválido (0 bytes).");
            }

            return new FileStorageResult
            {
                Path = fullPath,
                Size = fileInfo.Length
            };
        }

        public Task DeleteAsync(string path, CancellationToken cancellationToken)
        {
            if (File.Exists(path))
                File.Delete(path);

            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(string path, CancellationToken cancellationToken)
        {
            return Task.FromResult(File.Exists(path));
        }
    }

}
