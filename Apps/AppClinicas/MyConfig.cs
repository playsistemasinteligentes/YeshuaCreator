using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClinicas
{
    public class MyConfig
    {
        public MyConfig() { }
        public string ReadConectionString { get; set; }
        public string WriteConectionString { get; set; }
        public string HttpIPListen { get; set; }
        public int HttpPortListen { get; set; }
        public string HttpsIPListen { get; set; }
        public int HttpsPortListen { get; set; }
        public string HttpsPathCertificado { get; set; }
        public string HttpssenhaCertificado { get; set; }
        public int MaxConcurrentConnections { get; set; }
        public int MaxConcurrentUpgradedConnections { get; set; }
        public int MaxRequestBodySize { get; set; }
        public string[] CorsOrigins { get; set; }


    }
}
