using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Dominio
{
    public class QueueTopology
    {
        public QueueTopology(string exchangeName, ExchangeType exchangeType, string queueName, string routingKey)
        {
            ExchangeName = exchangeName;
            ExchangeType = exchangeType;
            QueueName = queueName;
            RoutingKey = routingKey;
        }

        public string ExchangeName { get; set; }
        public ExchangeType ExchangeType { get; set; }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
    }

    public enum ExchangeType
    {
        Direct,
        Fanout,
        Topic,
        Headers
    }
}