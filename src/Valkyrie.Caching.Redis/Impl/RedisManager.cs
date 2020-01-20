using System;
using System.Threading.Tasks;
using StackExchange.Redis;
using Valkyrie.Core.Contracts.Caching;


namespace Valkyrie.Caching.Redis.Impl
{
    //public class RedisManager : ICacheManager
    //{
    //    internal readonly IDatabase Database;
    //    protected readonly IRedisConnectionFactory ConnectionFactory;
    //    private readonly ITextSerializer _textSerializer;


    //    public RedisManager(IRedisConnectionFactory connectionFactory, ITextSerializer textSerializer)
    //    {
    //        ConnectionFactory = connectionFactory;
    //        _textSerializer = textSerializer;
    //        Database = ConnectionFactory.Connection().GetDatabase();
    //    }

    //    /// <summary>
    //    /// Check Key exists on redis
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public bool Exists(string key)
    //    {
    //        return Database.KeyExists(key);
    //    }

    //    public T Get<T>(string key)
    //    {
    //        var obj = _textSerializer.Deserialize<T>(Database.StringGet(key));
    //        return obj;
    //    }

    //    public async Task<T> GetAsync<T>(string key)
    //    {
    //        var valueString = await Database.StringGetAsync(key);
    //        return _textSerializer.Deserialize<T>(valueString);
    //    }

    //    public bool Set<T>(string key, T obj)
    //    {
    //        return Database.StringSet(key, _textSerializer.Serialize(obj));
    //    }

    //    /// <summary>
    //    /// TTL saniye cinsinden bir değer olmalıdır
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="key"></param>
    //    /// <param name="obj"></param>
    //    /// <param name="ttl"></param>
    //    /// <returns></returns>
    //    public bool Set<T>(string key, T obj, int ttl)
    //    {
    //        var ts = TimeSpan.FromSeconds(ttl);
    //        return Database.StringSet(key, _textSerializer.Serialize(obj), ts);
    //    }

    //    public async Task SetAsync<T>(string key, T obj)
    //    {
    //        await Database.StringSetAsync(key, _textSerializer.Serialize(obj));
    //    }

    //    /// <summary>
    //    /// TTL saniye cinsinden bir değer olmalıdır
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="key"></param>
    //    /// <param name="obj"></param>
    //    /// <param name="ttl"></param>
    //    /// <returns></returns>
    //    public async Task SetAsync<T>(string key, T obj, int ttl)
    //    {
    //        var ts = TimeSpan.FromSeconds(ttl);
    //        await Database.StringSetAsync(key, _textSerializer.Serialize(obj), ts);
    //    }

    //    public bool Remove<T>(string key)
    //    {
    //        return Database.KeyDelete(key);
    //    }

    //    public async Task<bool> RemoveAsync<T>(string key)
    //    {
    //        return await Database.KeyDeleteAsync(key);
    //    }
    //}
}