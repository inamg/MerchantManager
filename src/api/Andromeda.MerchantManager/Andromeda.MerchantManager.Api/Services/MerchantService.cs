using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromeda.MerchantManager.Api.Exceptions;
using Andromeda.MerchantManager.Api.Models;
using Andromeda.MerchantManager.Data;
using Andromeda.MerchantManager.Data.Entities;
using AutoMapper;
using Guards;
using Microsoft.Extensions.Logging;

namespace Andromeda.MerchantManager.Api.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<MerchantService> _logger;

        public MerchantService(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<MerchantService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Merchant> CreateMerchantAsync(Merchant merchant)
        {
            Guard.ArgumentNotNull(merchant, nameof(merchant));

            var merchantEntity = _mapper.Map<MerchantEntity>(merchant);
            try
            {
                _unitOfWork.MerchantRepository.Add(merchantEntity);
                await _unitOfWork.SaveChangesAsync();
                return await GetMerchantAsync(merchantEntity.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new MerchantSaveException(e.Message);
            }
        }

        public async Task<Merchant> GetMerchantAsync(Guid merchantId)
        {
            Guard.ArgumentCondition(merchantId, "merchantId", v => v != Guid.Empty);
            try
            {
                var merchantEntity = await _unitOfWork.MerchantRepository.GetById(merchantId);
                return _mapper.Map<Merchant>(merchantEntity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new MerchantGetException(e.Message);
            }
        }

        public async Task<IEnumerable<Merchant>> GetAllMerchantsAsync()
        {
            try
            {
                var merchants = await _unitOfWork.MerchantRepository.GetAll();

                return _mapper.Map<IEnumerable<Merchant>>(merchants);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new MerchantGetException(e.Message);
            }
        }

        public async Task<Merchant> UpdateMerchantAsync(Guid id, Merchant merchant)
        {
            Guard.ArgumentCondition(id, "id", v => v != Guid.Empty);
            Guard.ArgumentNotNull(merchant, nameof(merchant));

            try
            {
                var merchantEntity = _mapper.Map<MerchantEntity>(merchant);
                merchantEntity.Id = id;
                _unitOfWork.MerchantRepository.Update(merchantEntity);
                await _unitOfWork.SaveChangesAsync();

                return await GetMerchantAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new MerchantUpdateException(e.Message);
            }
        }

        public async Task<bool> DeleteMerchantAsync(Guid merchantId)
        {
            Guard.ArgumentCondition(merchantId, "merchantId", v => v != Guid.Empty);

            try
            {
                _unitOfWork.MerchantRepository.Remove(merchantId);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new MerchantDeleteException(e.Message);
            }
        }
    }
}