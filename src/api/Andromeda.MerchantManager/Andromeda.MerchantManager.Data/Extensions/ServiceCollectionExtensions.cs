using Microsoft.Extensions.DependencyInjection;

namespace Andromeda.MerchantManager.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<IMongoContext, MongoContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}