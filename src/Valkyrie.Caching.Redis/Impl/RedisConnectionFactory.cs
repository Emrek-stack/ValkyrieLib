using System;
using StackExchange.Redis;

namespace Valkyrie.Caching.Redis.Impl
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisConnectionFactory(string connectionString)
        {
            _connection = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(connectionString));
        }

        public ConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }
    }
}