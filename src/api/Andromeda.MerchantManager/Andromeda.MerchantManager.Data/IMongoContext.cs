using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Andromeda.MerchantManager.Data
{
    public interface IMongoContext
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChangesAsync();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}