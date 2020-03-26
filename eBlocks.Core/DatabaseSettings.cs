using eBlocks.Core.Interfaces;

namespace eBlocks.Core
{
    public class DatabaseSettings : ISettings
    {
 

        public string ConnectionStr { get ; set ; }
        public string DatabaseName { get ; set ; }

        public string CollectionName{get;set;}
    }
}
