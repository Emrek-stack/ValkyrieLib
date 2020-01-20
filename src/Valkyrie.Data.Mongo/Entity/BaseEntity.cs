using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Valkyrie.Data.Mongo.Entity
{
    public abstract class BaseEntity : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }
    }
}