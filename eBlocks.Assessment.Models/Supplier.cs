using eBlocks.Assessment.Models.Attributes;
using eBlocks.Assessment.Models.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eBlocks.Assessment.Models
{
    [BsonCollection("Suppliers")]
    public class Supplier: IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get ; set ; }
        [BsonElement("SupplierName")]
        public string Name {get;set;}
        public string ContactName{get;set;}
        public int ContactTitle {get;set;}        
        public string City {get;set;}
        public string Phone{get;set;}
        public string Fax {get;set;}
        public string Homepage {get;set;}
        [BsonElement("Address")]
        public string[] AddressInfo{get;set;}
        public string Region {get;set;}
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
