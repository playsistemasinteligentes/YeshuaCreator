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
            string fileName,
            FileSaveOptions options,
            CancellationToken cancellationToken);

        Task DeleteAsync(
            string path,
            CancellationToken cancellationToken);

        Task<bool> ExistsAsync(
            string path,
            CancellationToken cancellationToken);
    }
}
