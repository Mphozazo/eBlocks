using System;
using eBlocks.Assessment.Models.Interface;

namespace eBlocks.Assessment.Models
{
    public class Product : IEntity
    {
        public string Id { get ;set;}
        public string Name {get;set;}
        public int QuantityPerUnit{get;set;}
        public Guid SupplierId {get;set;}
        public decimal UnitPrice {get;set;}
        public int unitInStock {get;set;}
        public int UnitOnOrder {get;set;}
        public int ReorderLevel {get;set;}
        public Boolean Discontinued {get;set;}
    }
}
