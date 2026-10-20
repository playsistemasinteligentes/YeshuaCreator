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

            ValidateRelative(value);
            var category = value.Replace('\\', '/').Split('/')[0];
            if (category is not ("persistent" or "volatile"))
                throw new ArgumentException("StoragePath must belong to persistent or volatile.", nameof(value));

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

        internal static void ValidateRelative(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.StartsWith('/') || value.StartsWith('\\')
                || value.Contains(':') || value.Contains('\0')
                || value.Replace('\\', '/').TrimEnd('/').Split('/').Any(part => part is "" or "." or ".."))
                throw new ArgumentException("Storage paths must be relative and cannot traverse directories.", nameof(value));
        }

        public string ResolveUnder(string root)
        {
            if (string.IsNullOrWhiteSpace(root) || !Path.IsPathFullyQualified(root))
                throw new ArgumentException("Storage root must be absolute.", nameof(root));
            var fullRoot = Path.TrimEndingDirectorySeparator(Path.GetFullPath(root));
            var fullPath = Path.GetFullPath(Path.Combine(fullRoot, Value));
            var comparison = OperatingSystem.IsWindows() ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            var prefix = Path.EndsInDirectorySeparator(fullRoot) ? fullRoot : fullRoot + Path.DirectorySeparatorChar;
            if (!fullPath.StartsWith(prefix, comparison))
                throw new InvalidOperationException("Storage path escapes its configured root.");
            return fullPath;
        }
    }
}
