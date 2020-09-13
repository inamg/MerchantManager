using System;
using Andromeda.MerchantManager.Api.Models;
using Andromeda.MerchantManager.Data.Entities;
using AutoMapper;

namespace Andromeda.MerchantManager.Api.Infrastructure.Profiles
{
    public class ModelEntityMappings : Profile
    {
        public ModelEntityMappings()
        {
            CreateMap<Merchant, MerchantEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => GetOrCreateId(src.Id)));
            
            CreateMap<Currency, CurrencyEntity>();

            CreateMap<MerchantEntity, Merchant>();
            CreateMap<CurrencyEntity, Currency>();
        }

        private Guid GetOrCreateId(Guid id)
        {
            return id == default ? Guid.NewGuid() : id;
        }
    }
}