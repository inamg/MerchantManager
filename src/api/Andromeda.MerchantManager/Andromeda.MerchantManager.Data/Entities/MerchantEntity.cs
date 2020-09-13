using System;

namespace Andromeda.MerchantManager.Data.Entities
{
    public class MerchantEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CurrencyEntity Currency { get; set; }
        public string Image { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        
    }
}