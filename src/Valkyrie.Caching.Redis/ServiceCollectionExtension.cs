using Microsoft.Extensions.DependencyInjection;
using Valkyrie.Caching.Redis.Impl;


namespace Valkyrie.Caching.Redis
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCachingModule(this IServiceCollection services)
        {
            services
                .AddScoped<IRedisConnectionFactory, RedisConnectionFactory>();
                //.AddScoped(servicrProvider =>
                //{

                //    ICacheManager Accesor(CacheTypes key)
                //    {
                //        switch (key)
                //        {
                //            case CacheTypes.Data:
                //                return servicrProvider.GetService<RedisManager>();
                //            case CacheTypes.Product:
                //                return servicrProvider.GetService<RedisManager>();
                //            default:
                //                throw new KeyNotFoundException();
                //        }
                //    }

                //    return (Func<CacheTypes, ICacheManager>) Accesor;
                //});


            return services;
        }
    }
}
