using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.RabbitMQ;
using Serilog.Sinks.RabbitMQ.Sinks.RabbitMQ;
using Valkyrie.Logging.Exceptions;
using Valkyrie.Logging.Model;

namespace Valkyrie.Logging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValyrieLog(this IServiceCollection service, Action<ValkyrieLoggingOptions> options)
        {
            ValkyrieLoggingOptions valkyrie = new ValkyrieLoggingOptions();
            options?.Invoke(valkyrie);

            if (options == null)
            {
                throw new ConfigurationNotFoundException(nameof(options));
            }
            //var sb = service.BuildServiceProvider();
            //var config = sb.GetService<IConfiguration>();
            //service.Configure<ValkyrieLoggingOptions>(config.GetSection("Valkyrie:Log"));
            //var aa = sb.GetService<IOptions<ValkyrieLoggingOptions>>();
            //var section = config.GetSection("Logging");

            // Add our Config object so it can be injected


            //RabbitMQClientConfiguration rabbitMqClientConfiguration = new RabbitMQClientConfiguration();
            //options?.Invoke(rabbitMqClientConfiguration);
            //if (expr)
            //{

            //}

            var config = new RabbitMQClientConfiguration
            {
                Port = valkyrie.Port,
                DeliveryMode = valkyrie.DeliveryMode,
                Exchange = valkyrie.Exchange,
                Username = valkyrie.Username,
                Password = valkyrie.Password,
                ExchangeType = valkyrie.ExchangeType,

            };
            foreach (string hostname in valkyrie.Hostnames)
            {
                config.Hostnames.Add(hostname);
            }

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