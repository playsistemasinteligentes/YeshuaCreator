using System;
namespace Shered.Configuration
{
    public class MyConfig
    {
        public MyConfig() { }
        public string ReadConectionString { get; set; } = string.Empty;
        public string WriteConectionString { get; set; } = string.Empty;
        public int MaxConcurrentConnections { get; set; }
        public int MaxConcurrentUpgradedConnections { get; set; }
        public int MaxRequestBodySize { get; set; }
        public string[] CorsOrigins { get; set; } = Array.Empty<string>();
    }

}
