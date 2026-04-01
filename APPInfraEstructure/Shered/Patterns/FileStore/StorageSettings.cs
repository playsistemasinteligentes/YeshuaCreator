using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Patterns.FileStore
{
    public class StorageSettings
    {
        public Dictionary<string, StorageProviderSettings> Providers { get; set; } = new();
        public Dictionary<string, string> Locations { get; set; } = new();
    }
}
