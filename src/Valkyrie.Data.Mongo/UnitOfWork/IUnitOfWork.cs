using MongoDB.Driver;

namespace Valkyrie.Data.Mongo.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
        IMongoDatabase CreateNewDatabase();
    }
}
