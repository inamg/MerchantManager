using Microsoft.AspNetCore.Http;

namespace Andromeda.MerchantManager.Api.Models
{
    public class Image
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }
    }
}