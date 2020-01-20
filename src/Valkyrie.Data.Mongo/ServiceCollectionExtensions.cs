using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Valkyrie.Data.Mongo.UnitOfWork;

namespace Valkyrie.Data.Mongo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseMongoDb(this IServiceCollection services, Action<MongoOptions> connection)
        {
            MongoOptions mongoOptions = new MongoOptions();
            connection?.Invoke(mongoOptions);
            services.AddScoped<IUnitOfWork>(provider =>
                new UnitOfWork.Impl.UnitOfWork(mongoOptions.ConnectionString));
            return services;
        }
    }
}