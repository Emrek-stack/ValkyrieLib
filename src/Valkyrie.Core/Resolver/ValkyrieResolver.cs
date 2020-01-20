using System;
using Microsoft.Extensions.DependencyInjection;
using Valkyrie.Core.Extensions;

namespace Valkyrie.Core.Resolver
{
    public class ValkyrieResolver : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public ValkyrieResolver()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.RegisterAttributes();
            serviceCollection.RegisterConfigurationAttributes();
            serviceCollection.RegisterSchedulerJobAttributes();

            ServiceProvider = serviceCollection.BuildServiceProvider();


            ServiceProvider.InitializeSchedulerJob();

        }

        public IServiceProvider ServiceProvider { get; set; }

        public void Dispose()
        {

        }
    }
}
