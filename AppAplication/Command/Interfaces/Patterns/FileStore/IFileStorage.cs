using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.FileStore
{
    public interface IFileStorage
    {
        Task<FileStorageResult> SaveAsync(
            IFormFile stream,
            StoragePath path,
            CancellationToken cancellationToken);

        Task DeleteAsync(
            StoragePath path,
            CancellationToken cancellationToken);

        Task<bool> ExistsAsync(
            StoragePath path,
            CancellationToken cancellationToken);

        Task<bool> HasFilesInDirectoryAsync(
            StoragePath path,
            CancellationToken cancellationToken);

        IEnumerable<StoragePath> ListFiles(StoragePath path);

        Stream OpenRead(StoragePath path);

        Stream OpenWrite(StoragePath path);
        string GetBaseUrl();
        
        bool DirectoryExists(StoragePath path);
    }
}
