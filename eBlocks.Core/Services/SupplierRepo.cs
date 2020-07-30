using System;
using eBlocks.Core.Repo.Mongodb;
using eBlocks.Assessment.Models;
using eBlocks.Core.Interfaces;

namespace eBlocks.Core.Services
{
    public class SupplierRepo : RepositoryService<Supplier>
    {
        public SupplierRepo(IDatabaseSettings _settings) : base(_settings)
        {
        }

        
    }
}
