using Andromeda.MerchantManager.Api.Infrastructure.Profiles;
using AutoMapper;
using Xunit;

namespace Andromeda.MerchantManager.Tests.Profiles
{
    public class ModelEntityMappingsTests
    {
        private readonly MapperConfiguration _mapperConfiguration;

        public ModelEntityMappingsTests()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelEntityMappings());
            });
        }

        [Fact]
        public void ModelEntityMappingsConfiguration_IsValid()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}