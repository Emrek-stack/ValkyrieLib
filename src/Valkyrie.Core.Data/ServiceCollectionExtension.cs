using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Valkyrie.Data.Ef.Repository;
using Valkyrie.Data.Ef.Repository.Impl;

namespace Valkyrie.Data.Ef
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection UseEntityFramework<T>([NotNull] this IServiceCollection serviceCollection,
            Action<DbContextOptionsBuilder> optionsAction = null,
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped) where T : DbContext
        {
            serviceCollection.AddDbContext<T>(optionsAction)
                .UseRepostitory();
            
            return serviceCollection;
        }

        private static IServiceCollection UseRepostitory([NotNull] this IServiceCollection serviceCollection)
        {
            if (serviceCollection.All(x => x.ServiceType != typeof(IRepository<>)))
            {
                serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<,>));
            }
            return serviceCollection;
        }
    }
}
