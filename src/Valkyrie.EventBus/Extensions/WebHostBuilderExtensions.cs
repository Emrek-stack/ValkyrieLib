using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Valkyrie.EventBus.Exception;

namespace Valkyrie.EventBus.Extensions
{
    public static class WebHostBuilderExtensions
    {

        #region Private Member of WebHostBuilderExtensions

        private static readonly List<string> Instances = new List<string>();

        #endregion

        #region Public Methods of WebHostBuilderExtensions

        /// <summary>
        /// Use RabbitMq Client
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="instanceName">Instance name must be equal with configuration section name, Default value is 'RabbitMq'</param>
        /// <returns></returns>
        public static IWebHostBuilder UseRabbitMq(this IWebHostBuilder hostBuilder, string instanceName = "RabbitMq")
        {

            if (Instances.Contains(instanceName))
                throw new ConfigurationException("Multiple client using with same instance name. Please check using of 'UseRabbitMq()' ");

            hostBuilder.ConfigureServices(collection =>
            {
                collection.RegisterBusProvider();
                collection.RegisterConsumer(instanceName);
            });

            Core.Valkyrie.StartupAction.Add(builder =>
            {
                builder.ConfigureConsumer(instanceName);

            });

            Instances.Add(instanceName);

            return hostBuilder;

        }

        #endregion
        
    }
}

