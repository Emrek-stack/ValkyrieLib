using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.RabbitMQ;
using Serilog.Sinks.RabbitMQ.Sinks.RabbitMQ;
using Valkyrie.Core.Extensions;
using Valkyrie.EventBus.Extensions;

namespace Valkyrie.Sample.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var config = new RabbitMQClientConfiguration
            //{
            //    Hostnames = { "127.0.0.1" },
            //    Username = "guest",
            //    Password = "guest",
            //    Exchange = "app-logging",
            //    ExchangeType = "direct",
            //    DeliveryMode = RabbitMQDeliveryMode.NonDurable,
            //    RouteKey = "Logs",
            //    Port = 5672
            //};

            var config = new RabbitMQClientConfiguration
            {
                Port = 5672,
                DeliveryMode = RabbitMQDeliveryMode.Durable,
                Exchange = "logging",
                Username = "guest",
                Password = "guest",
                ExchangeType = "direct"
            };
            config.Hostnames.Add("localhost");


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.RabbitMQ((clientConfiguration, sinkConfiguration) =>
                {
                    clientConfiguration.From(config);
                    sinkConfiguration.TextFormatter = new JsonFormatter();
                })
                .WriteTo.Console()
                .CreateLogger();
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseValkyrie<Startup>();
                    webBuilder.UseRabbitMq();
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog();
                });
    }
}
