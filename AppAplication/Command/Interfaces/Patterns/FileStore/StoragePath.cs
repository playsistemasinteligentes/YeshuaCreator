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

        internal StoragePath(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("StoragePath cannot be empty.", nameof(value));

            Value = value.Replace("\\", "/");
        }

        public override string ToString() => Value;
    }
}
