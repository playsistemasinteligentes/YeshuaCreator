using Command.Patterns.FileStore;
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
            Stream stream,
            string fileName,
            CancellationToken cancellationToken);

        Task DeleteAsync(
            string path,
            CancellationToken cancellationToken);

        Task<bool> ExistsAsync(
            string path,
            CancellationToken cancellationToken);
    }

}
