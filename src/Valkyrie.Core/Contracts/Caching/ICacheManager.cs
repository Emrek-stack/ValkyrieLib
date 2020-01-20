using System.Threading.Tasks;

namespace Valkyrie.Core.Contracts.Caching
{
    public interface ICacheManager
    {
        bool Exists(string key);
        T Get<T>(string key);
        Task<T> GetAsync<T>(string key);
        bool Set<T>(string key, T obj);
        bool Set<T>(string key, T obj, int ttl);
        Task SetAsync<T>(string key, T obj);
        Task SetAsync<T>(string key, T obj, int ttl);
        bool Remove<T>(string key);
        Task<bool> RemoveAsync<T>(string key);
        
    }
}