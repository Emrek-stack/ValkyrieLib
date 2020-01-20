using System;
using FluentScheduler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Valkyrie.Core.Extensions;

namespace Valkyrie.Core.Startup
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
               
                // Get configuration
                var configureation =  builder.ApplicationServices.GetService<IConfiguration>();


                // Invoke Valkyrie actions
                foreach (var action in Valkyrie.StartupAction)
                {
                    action.Invoke(builder);
                }


                // On application start
                var appLifetime = builder.ApplicationServices.GetService<IApplicationLifetime>();

                appLifetime.ApplicationStarted.Register(() =>
                {
                    builder.ApplicationServices.InitializeSchedulerJob();

                });
                appLifetime.ApplicationStopped.Register(JobManager.StopAndBlock);

                
                next(builder);
            };
        }
        
   
    }
}
