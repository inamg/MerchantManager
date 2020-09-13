using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Andromeda.MerchantManager.Api.Services
{
    public interface IStorageService
    {
        Task<string> SaveAsync(IFormFile file);
    }
}