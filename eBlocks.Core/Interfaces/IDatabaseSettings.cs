namespace eBlocks.Core.Interfaces
{
    public interface IDatabaseSettings
    {
        string Connection { get;set;}
        string DatabaseName {get;set;}
        string Username { get; set; }
        string Password { get; set; }
        string ConnString { get; }

    }
}
