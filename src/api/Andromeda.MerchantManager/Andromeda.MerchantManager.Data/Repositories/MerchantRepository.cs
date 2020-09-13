using Andromeda.MerchantManager.Data.Entities;

namespace Andromeda.MerchantManager.Data.Repositories
{
    public class MerchantRepository : BaseRepository<MerchantEntity> , IMerchantRepository
    {
        public MerchantRepository(IMongoContext context) : base(context)
        {}
    }
}