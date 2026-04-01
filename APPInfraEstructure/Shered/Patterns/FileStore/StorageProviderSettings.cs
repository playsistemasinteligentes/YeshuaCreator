using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Patterns.FileStore
{
    public class StorageProviderSettings
    {
        public string? Root { get; set; }     // Disk
        public string? Bucket { get; set; }   // S3
        public string? Region { get; set; }   // S3
        public string? BaseUrl { get; set; }  // Público
    }
}
