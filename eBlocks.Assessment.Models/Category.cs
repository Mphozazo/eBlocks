using eBlocks.Assessment.Models.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eBlocks.Assessment.Models
{
    public class Category : IEntity
    {

        public string Id { get ; set ; }

        public string Name {get;set;}
        public string Description {get;set;}

        [BsonRepresentation(BsonType.Binary)]
        public byte[] Picture {get;set;}
    }
}
