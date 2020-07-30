using eBlocks.Assessment.Models;
using eBlocks.Core.Interfaces;
using eBlocks.Core.Repo.Mongodb;

namespace eBlocks.Core.Services
{
    public class OrderDetailRepo : RepositoryService<OrderDetails>
    {
        public OrderDetailRepo(IDatabaseSettings _settings) : base(_settings)
        {
        }
    }
}
