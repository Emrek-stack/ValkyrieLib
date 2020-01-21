using System.Collections.Generic;
using RabbitMQ.Client;
using Serilog.Sinks.RabbitMQ;

namespace Valkyrie.Logging.Model
{
    public class ValkyrieLoggingOptions
    {
        public IList<string> Hostnames { get; } = (IList<string>)new List<string>();

        public string Username { get; set; } 

        public string Password { get; set; } 

        public string Exchange { get; set; } 

        public string ExchangeType { get; set; } 

        public RabbitMQDeliveryMode DeliveryMode { get; set; } 

        public string RouteKey { get; set; } 

        public int Port { get; set; }

        public string VHost { get; set; }

        //public IProtocol Protocol { get; set; }

        public ushort Heartbeat { get; set; }

        public bool UseBackgroundThreadsForIO { get; set; }

        //public SslOption SslOption { get; set; }
    }
}