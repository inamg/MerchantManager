using System.Threading.Tasks;
using Andromeda.MerchantManager.Data.Repositories;

namespace Andromeda.MerchantManager.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;
        public IMerchantRepository MerchantRepository { get; }

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
            
            MerchantRepository = new MerchantRepository(_context);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var changeAmount = await _context.SaveChangesAsync();

            return changeAmount > 0;
        }
    }
}