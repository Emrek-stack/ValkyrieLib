using StackExchange.Redis;

namespace Valkyrie.Caching.Redis
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}