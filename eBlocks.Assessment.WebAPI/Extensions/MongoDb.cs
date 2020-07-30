using eBlocks.Core;
using eBlocks.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using eBlocks.Core.Interfaces;
using eBlocks.Core.Repo.Mongodb;

namespace eBlocks.Assessment.WebAPI.Extensions
{
    public static class MongoDb
    {
        public static void AddRepoServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>),typeof(RepositoryService<>));
            //services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
            services.AddScoped<SupplierRepo>();
            services.AddScoped<ProductRepo>();
            services.AddScoped<OrderDetailRepo>();
            services.AddScoped<CategoriesRepo>();
            

        }
    }
}
