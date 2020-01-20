using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.RabbitMQ;
using Serilog.Sinks.RabbitMQ.Sinks.RabbitMQ;

namespace Valkyrie.Logging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValyrieLog(this IServiceCollection service)
        {
            var config = new RabbitMQClientConfiguration
            {
                Port = 5672,
                DeliveryMode = RabbitMQDeliveryMode.Durable,
                Exchange = "logging",
                Username = "guest",
                Password = "guest",
                ExchangeType = "direct",

            };
            config.Hostnames.Add("localhost");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.RabbitMQ((clientConfiguration, sinkConfiguration) =>
                {
                    clientConfiguration.From(config);
                    sinkConfiguration.TextFormatter = new JsonFormatter();
                })
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
                .CreateLogger();

            service.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));
            return service;
        }
    }
}