using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.FileStore
{
    public sealed class StoragePath
    {
        public string Value { get; }

        public StoragePath(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("StoragePath cannot be empty.", nameof(value));

            // Normaliza para o separador do sistema
            Value = value.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
        }

        public string FileName => Path.GetFileName(Value);
        public string FileNameWithoutExtension => Path.GetFileNameWithoutExtension(Value);
        public string? Directory => Path.GetDirectoryName(Value)?.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
        public string Extension => Path.GetExtension(Value);

        public bool HasExtension => !string.IsNullOrEmpty(Extension);
        public bool IsFile => HasExtension;
        public bool IsDirectory => !HasExtension;

        public override string ToString() => Value;
    }
}
