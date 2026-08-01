using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Interfaces.Patterns.FileStore
{
    public readonly record struct StorageKey_(string Value)
    {
        public override string ToString() => Value;
    }

}
