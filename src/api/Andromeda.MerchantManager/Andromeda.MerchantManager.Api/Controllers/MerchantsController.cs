using System;
using System.Threading.Tasks;
using Andromeda.MerchantManager.Api.Models;
using Andromeda.MerchantManager.Api.Services;
using Guards;
using Microsoft.AspNetCore.Mvc;

namespace Andromeda.MerchantManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MerchantsController : ControllerBase
    {
        private readonly IMerchantService _merchantService;
        private readonly IStorageService _storageService;

        public MerchantsController(IMerchantService merchantService,
            IStorageService storageService)
        {
            _merchantService = merchantService;
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var merchants = await _merchantService.GetAllMerchantsAsync();
            return Ok(merchants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            Guard.ArgumentNotNull(id, nameof(id));

            var merchant = await _merchantService.GetMerchantAsync(id);
            return Ok(merchant);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Merchant merchant)
        {
            if (!ModelState.IsValid)
            {
                // can be replaced by validation attribute
                return BadRequest(ModelState);
            }

            await _merchantService.CreateMerchantAsync(merchant);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] Merchant merchant)
        {
            if (!ModelState.IsValid)
            {
                // can be replaced by validation attribute
                return BadRequest(ModelState);
            }

            await _merchantService.UpdateMerchantAsync(id, merchant);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Guard.ArgumentNotNull(id, nameof(id));

            await _merchantService.DeleteMerchantAsync(id);
            return Ok();
        }
    }
}