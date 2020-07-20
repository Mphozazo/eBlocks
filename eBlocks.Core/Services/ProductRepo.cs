using System;
using eBlocks.Assessment.Models;
using eBlocks.Core.Repo.Mongodb;

namespace eBlocks.Core.Services
{
    public class ProductRepo : RepositoryService<Product> 
    {
        public ProductRepo(DatabaseSettings dbSettings):base(dbSettings){         
        }

    }
}
