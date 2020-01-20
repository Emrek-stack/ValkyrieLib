using System;
using System.Reflection;
using FluentScheduler;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Valkyrie.Core.Startup;

namespace Valkyrie.Core.Extensions
{
    public static class WebHostBuilderExtensions
    {
        
        public static IWebHostBuilder UseValkyrie<TStartup>(this IWebHostBuilder hostBuilder, string applicationName = null) where TStartup : class
        {

            var startupName = typeof(TStartup).GetTypeInfo().Assembly.GetName().Name;
            
            hostBuilder.UseSetting(WebHostDefaults.ApplicationKey, applicationName ?? startupName);

            hostBuilder.ConfigureServices(collection =>
            {
                // Register Valkyrie services by attributes
                collection.RegisterAttributes();

                // Register Valkyrie configurations by attributes
                collection.RegisterConfigurationAttributes();

                // Register Valkyrie Scheduler job by attributes
                collection.RegisterSchedulerJobAttributes();

                // Add configured application & Configurition of using of Valkyrie application 
                collection.AddTransient<IStartupFilter, StartupFilter>();

            });

            hostBuilder.UseStartup(startupName);

            return hostBuilder;

        }


        /// <summary>
        /// Use Daylight Saving Time
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseUtcTime(this IWebHostBuilder hostBuilder) 
        {

            // Json Serializer Settings
            Valkyrie.JsonSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            //  FLuent Scheduler Timing
            JobManager.UseUtcTime();

            return hostBuilder;

        }

        /// <summary>
        /// Use Local Time
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseLocalTime(this IWebHostBuilder hostBuilder)
        {

            // Json Serializer Settings
            Valkyrie.JsonSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            

            return hostBuilder;

        }


        /// <summary>
        /// Configure Valkyrie Json Option
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="options">Newtonsoft Json Serializer Settings</param>
        /// <returns></returns>
        public static IWebHostBuilder ConfigureValkyrieJsonOption(this IWebHostBuilder hostBuilder, Action<JsonSerializerSettings> options)
        {

            options.Invoke(Valkyrie.JsonSerializerSettings);


            return hostBuilder;

        }
    }
}

