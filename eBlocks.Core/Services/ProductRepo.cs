using eBlocks.Assessment.Models;
using eBlocks.Core.Interfaces;
using eBlocks.Core.Repo.Mongodb;

namespace eBlocks.Core.Services
{
    public class ProductRepo : RepositoryService<Product> 
    {
        public ProductRepo(IDatabaseSettings dbSettings):base(dbSettings){         
        }

    }
}
