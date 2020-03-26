using System;
using eBlocks.Core.Repo.Mongodb;
using eBlocks.Assessment.Models;

namespace eBlocks.Core.Services
{
    public class SupplierRepo : RepositoryService<Supplier, DatabaseSettings>
    {
        public SupplierRepo(DatabaseSettings _settings) : base(_settings)
        {
        }
    }
}
