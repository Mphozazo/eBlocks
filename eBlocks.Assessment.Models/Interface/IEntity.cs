using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace eBlocks.Assessment.Models.Interface
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }

        string Name {get;set;}
    }
}
