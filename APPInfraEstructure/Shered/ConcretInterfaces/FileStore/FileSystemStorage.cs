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
        private readonly string _baseUrl;

        public FileSystemStorage(IOptions<FileSystemOptions> options)
        {
            _rootPath = options.Value.RootPath;
            _baseUrl = options.Value.BaseUrl;
            Directory.CreateDirectory(_rootPath);
        }

        public async Task<FileStorageResult> SaveAsync(IFormFile file, StoragePath path, CancellationToken cancellationToken)
        {
            var fullPath = Path.Combine(_rootPath, path.Value);

            var directory = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory!);

            await using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
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
        public Task<bool> HasFilesInDirectoryAsync(StoragePath path, CancellationToken cancellationToken)
        {
            // Verifica se existe pelo menos 1 arquivo dentro
            var hasFiles = Directory.EnumerateFiles(Path.Combine(_rootPath, path.Directory)).Any();

            return Task.FromResult(hasFiles);
        }
        public object ListFiles(string pendingPath, string v)
        {
            throw new NotImplementedException();
        }

        public object OpenWrite(string finalPath)
        {
            throw new NotImplementedException();
        }

        public bool DirectoryExists(StoragePath path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return Directory.Exists(path.Value);
        }

        public IEnumerable<StoragePath> ListFiles(StoragePath path)
        {
            if (path == null || string.IsNullOrWhiteSpace(path.Value))
                yield break;
            string fullPath = Path.Combine(_rootPath, path.Directory);

            if (!Directory.Exists(fullPath))
                yield break;

            foreach (var filePath in Directory.GetFiles(fullPath))
            {
                // Criando StoragePath via builder
                yield return StoragePathBuilder.Build(StorageLocation.Volatile.TranscriptionsInput, filePath);
            }
        }
        public Stream OpenRead(StoragePath path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            // Combina com a raiz do storage
            var fullPath = Path.Combine(_rootPath, path.Value);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"File not found: {fullPath}", fullPath);

            // Abre para leitura compartilhada
            return new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public string GetBaseUrl()
        {
            return _baseUrl;
        }

        public Stream OpenWrite(StoragePath path)
        {
            var fullPath = Path.Combine(_rootPath, path.Value);

            var directory = Path.GetDirectoryName(fullPath)!;

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return new FileStream(fullPath, FileMode.Create, FileAccess.Write);
        }
    }
}
