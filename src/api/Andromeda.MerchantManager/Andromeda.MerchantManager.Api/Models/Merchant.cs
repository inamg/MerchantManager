using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Andromeda.MerchantManager.Api.Models
{
    public class Merchant
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Currency Currency { get; set; }
        [Required]
        public string Image { get; set; }
       // public IFormFile File { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}