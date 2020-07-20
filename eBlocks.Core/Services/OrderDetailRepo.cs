using eBlocks.Assessment.Models;
using eBlocks.Core.Repo.Mongodb;

namespace eBlocks.Core.Services
{
    public class OrderDetailRepo : RepositoryService<OrderDetails>
    {
        public OrderDetailRepo(DatabaseSettings _settings) : base(_settings)
        {
        }
    }
}
