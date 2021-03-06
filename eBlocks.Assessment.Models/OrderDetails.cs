using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using eBlocks.Assessment.Models.Interface;
using eBlocks.Assessment.Models.Attributes;

namespace eBlocks.Assessment.Models
{
    [BsonCollection("OrderDetails")]
    public class OrderDetails : IEntity
    {
        public string Id { get ; set ; }
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string ProductId  {get;set;}
        public decimal UnitPrice {get;set;}
        public decimal Discount {get;set;}
        public string Name { get ; set ; }
    }
}
