using System;

namespace eBlocks.Core.Interfaces
{
    public interface ISettings
    {
        string ConnectionStr {get;set;}
        string DatabaseName {get;set;}

         string CollectionName { get; set; }
    }
}
