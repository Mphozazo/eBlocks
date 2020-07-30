using eBlocks.Core.Interfaces;

namespace eBlocks.Core
{
    public class DatabaseSettings : IDatabaseSettings 
    {
        public string Connection { get ; set ; }
        public string DatabaseName { get ; set ; }
        public string Username { get; set; }
        public string Password { get;  set ; }

        public string ConnString => $"mongodb://{Username}:{Password}@{Connection}/{DatabaseName}?authSource = {DatabaseName}" ;
    }
}
