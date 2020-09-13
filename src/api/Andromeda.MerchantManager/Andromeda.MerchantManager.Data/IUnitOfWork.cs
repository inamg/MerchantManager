using System;
using System.Threading.Tasks;
using Andromeda.MerchantManager.Data.Repositories;

namespace Andromeda.MerchantManager.Data
{
    public interface IUnitOfWork
    {
        IMerchantRepository MerchantRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}