using System;
using System.IO;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Valkyrie.Core.Extensions;
using Valkyrie.Data.Ef;
using Valkyrie.Data.Mongo;
using Valkyrie.EventBus.Extensions;
using Valkyrie.Security.Extensions;
using Valkyrie.Security.Extensions.Constants.Constraints;

namespace Valkyrie.EventBus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection
                .UseMongoDb(options => { options.ConnectionString = "mongodb://localhost:27017/generic"; })
                .UseEntityFramework<DataContext>(o => { o.UseSqlServer("connection"); })
                .UseEntityFramework<DataContext2>(o => { o.UseSqlServer("connection"); })
                .UseAuthentication(o =>
                {
                    o.AuthenticationScheme = AuthenticationSchemes.Cookies;
                    o.DefaultChallengeScheme = "oidc";
                    o.SaveTokens = true;
                    o.IdentityServerUrl = "http://localhost:5000";
                    o.Scopes.Add("api1");

                });


            var sb = serviceCollection.BuildServiceProvider();
            sb = serviceCollection.BuildServiceProvider();

            var aa = sb.GetService<IConfiguration>();


            var conf = sb.GetService<AppConfig>();

            var bus = sb.GetService<IBus>();
            var endpoint = bus.GetSendEndpoint(new Uri("rabbitmq://localhost/test.denemesi")).Result;
            endpoint.Send(new Message { Data = "test" }).Wait();


        }

        public class Message
        {
            public string Data { get; set; }
        }
    }
}
