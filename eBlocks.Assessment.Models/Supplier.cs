using eBlocks.Assessment.Models.Interface;

namespace eBlocks.Assessment.Models
{
    public class Supplier : IEntity
    {
       public string Id { get ; set ; }
        public string Name {get;set;}
        public string ContactPerson{get;set;}
        public int Title {get;set;}
        public string City {get;set;}
        public string Phone{get;set;}
        public string Fax {get;set;}
        public string Homepage {get;set;}
        public string[] Address{get;set;}
        public string Region {get;set;}
        
    }
}
