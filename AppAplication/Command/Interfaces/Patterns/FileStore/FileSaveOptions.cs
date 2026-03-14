using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.FileStore
{
    public class FileSaveOptions
    {
        public required StorageKey Storage { get; init; }

        public required string Tenant { get; init; }

        public string? Prefix { get; init; }
    }
}
