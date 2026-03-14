using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.FileStore
{
    public class FileStorageResult
    {
        public string Path { get; init; }
        public long Size { get; init; }
    }

}
