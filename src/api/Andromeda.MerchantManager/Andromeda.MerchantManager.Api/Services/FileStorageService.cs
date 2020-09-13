using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Andromeda.MerchantManager.Api.Services
{
    public class FileStorageService : IStorageService
    {
        private const string StorageLocation = "C:\\mylab\\images";
        /// <summary>
        /// Saves the file passed and returns the path
        /// </summary>
        /// <param name="file"></param>
        /// <returns>path of the saved file</returns>
        public async Task<string> SaveAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                var filePath = Path.Combine(new []{StorageLocation, file.Name});

                await using var stream = File.Create(filePath);
                await file.CopyToAsync(stream);
                
                return filePath;
            }
            
            throw new Exception("empty file exception");
        }
    }
}