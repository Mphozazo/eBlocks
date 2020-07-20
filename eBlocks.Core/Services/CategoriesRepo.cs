using eBlocks.Assessment.Models;
using eBlocks.Core.Repo.Mongodb;

namespace eBlocks.Core.Services
{
    public class CategoriesRepo : RepositoryService<Category>
    {
        public CategoriesRepo(DatabaseSettings _settings) : base(_settings)
        {
        }
    }
}
