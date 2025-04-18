using Microsoft.AspNetCore.Mvc;
using StoreManagmentBL.Models;
using StoreManagmentBL.Services.Interfaces;

namespace StoreManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost("CreateStore")]
        public async Task<IActionResult> CreatePet([FromBody] StoreDto storeDto)
        {
            var storeId = await _storeService.CreateStore(storeDto);
            return Ok(storeId);
        }

        [HttpPost("UpdateStore")]
        public async Task<IActionResult> UpdateStore([FromQuery] Guid id, StoreDto storeDto)
        {
            var storeId = await _storeService.UpdateStore(id, storeDto);
            return Ok(storeId);
        }

        [HttpGet("GetAllStores")]
        public async Task<IActionResult> GetAllStores()
        {
            var stores = await _storeService.GetAllStores();
            return Ok(stores);
        }

        [HttpPost("GetStorePets")]
        public async Task<IActionResult> GetStorePets([FromBody] Guid id)
        {
            var pets = await _storeService.GetStorePets(id);
            return Ok(pets);
        }
    }
}
