using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Configuration
{
    public class MyConfig
    {
        public MyConfig() { }
        public string ReadConectionString { get; set; }
        public string WriteConectionString { get; set; }
        public string ReadConectionStringHML { get; set; }
        public string WriteConectionStringHML { get; set; }
        public RabbitMqOptions RabbitMQ { get; set; } = new RabbitMqOptions();

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

    public class RabbitMqOptions
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public string Exchange { get; set; }
        public string Queue { get; set; }
        public string RoutingKey { get; set; }
    }

}
