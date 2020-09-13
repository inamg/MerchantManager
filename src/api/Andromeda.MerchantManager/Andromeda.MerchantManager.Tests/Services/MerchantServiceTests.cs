using System;
using Andromeda.MerchantManager.Api.Models;
using Andromeda.MerchantManager.Api.Services;
using Andromeda.MerchantManager.Data;
using Andromeda.MerchantManager.Data.Entities;
using Andromeda.MerchantManager.Data.Repositories;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Andromeda.MerchantManager.Tests.Services
{
    public class MerchantServiceTests
    {
        private readonly MerchantService _merchantService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Fixture _fixture;

        public MerchantServiceTests()
        {
            _mapper = Substitute.For<IMapper>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            var logger = Substitute.For<ILogger<MerchantService>>();

            _merchantService = new MerchantService(_unitOfWork, _mapper, logger);
            _fixture = new Fixture();
        }

        [Fact]
        public void GetMerchantAsync_WhenGuidIsDefault_ShouldThrowException()
        {
            //Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _merchantService.GetMerchantAsync(Guid.Empty));
        }

        [Fact]
        public async void GetMerchantAsync_WhenGuidIsNotDefault_ShouldReturnMerchant()
        {
            // Arrange 
            var id = _fixture.Create<Guid>();
            var merchant = _fixture.Create<Merchant>();
            var merchantEntity = _fixture.Create<MerchantEntity>();

            var merchantRepository = Substitute.For<IMerchantRepository>();
            merchantRepository.GetById(id).Returns(merchantEntity);
            _unitOfWork.MerchantRepository.Returns(merchantRepository);
            _mapper.Map<Merchant>(merchantEntity).Returns(merchant);

            // Act
            var actualMerchant = await _merchantService.GetMerchantAsync(id);

            //Assert
            actualMerchant.Should().BeEquivalentTo(merchant);
        }

        [Fact]
        public void CreateMerchantAsync_MerchantIsNull_ShouldThrowException()
        {
            //Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _merchantService.CreateMerchantAsync(null));
        }

        [Fact]
        public void UpdateMerchantAsync_MerchantIdIsDefault_ShouldThrowException()
        {
            //Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _merchantService.UpdateMerchantAsync(Guid.Empty, null));
        }

        [Fact]
        public void DeleteMerchantAsync_MerchantIdIsDefault_ShouldThrowException()
        {
            //Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _merchantService.DeleteMerchantAsync(Guid.Empty));
        }
    }
}