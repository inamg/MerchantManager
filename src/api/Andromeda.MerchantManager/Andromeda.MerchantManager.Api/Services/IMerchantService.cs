using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromeda.MerchantManager.Api.Models;

namespace Andromeda.MerchantManager.Api.Services
{
    public interface IMerchantService
    {
        Task<Merchant> CreateMerchantAsync(Merchant merchant);
        Task<Merchant> GetMerchantAsync(Guid merchantId);
        Task<IEnumerable<Merchant>> GetAllMerchantsAsync();
        Task<Merchant> UpdateMerchantAsync(Guid id, Merchant merchant);
        Task<bool> DeleteMerchantAsync(Guid merchantId);
    }
}