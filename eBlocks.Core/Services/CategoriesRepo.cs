using eBlocks.Assessment.Models;
using eBlocks.Core.Interfaces;
using eBlocks.Core.Repo.Mongodb;

namespace eBlocks.Core.Services
{
    public class CategoriesRepo : RepositoryService<Category>
    {
        public CategoriesRepo(IDatabaseSettings _settings) : base(_settings)
        {
        }
    }
}
