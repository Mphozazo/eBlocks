using eBlocks.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eBlocks.Assessment.WebAPI.Extensions
{
    public static class MongoDb
    {
        public static void AddRepoServices(this IServiceCollection services)
        {
      
           services.AddSingleton<SupplierRepo>();
           services.AddSingleton<ProductRepo>();
           services.AddSingleton<OrderDetailRepo>();
           services.AddSingleton<CategoriesRepo>();
            

        }
    }
}
