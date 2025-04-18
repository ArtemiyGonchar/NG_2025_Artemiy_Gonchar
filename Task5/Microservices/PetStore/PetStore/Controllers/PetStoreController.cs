using DAL_Core.Entities;
using Microsoft.AspNetCore.Mvc;
using PetStoreBL.Enums;
using PetStoreBL.Models;
using PetStoreBL.Services.Interfaces;

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetStoreController : ControllerBase
    {
        private readonly IPetStoreService _petStoreService;

        public PetStoreController(IPetStoreService petStoreService)
        {
            _petStoreService = petStoreService;
        }

        [HttpPost("AddPet")]
        public async Task<IActionResult> AddPet([FromBody] PetStoreDto petDto)
        {
            var petId = await _petStoreService.AddPet(petDto);
            return Ok(petId);
        }

        [HttpPost("GetPetById")]
        public async Task<IActionResult> GetPetById([FromBody] Guid id)
        {
            var petStoreDto = await _petStoreService.GetPetById(id);
            return Ok(petStoreDto);
        }

        [HttpGet("GetAllPets")]
        public async Task<IActionResult> GetAllPets()
        {
            var petStoreList = await _petStoreService.GetAllPets();
            return Ok(petStoreList);
        }

        [HttpPost("GetPetsByStore")]
        public async Task<IActionResult> GetPetsByStore([FromBody] Guid storeId)
        {
            var pets = await _petStoreService.GetPetsByStore(storeId);
            return Ok(pets);
        }

        [HttpPost("GetPetsByType")]
        public async Task<IActionResult> GetPetsByType(PetTypesBL type)
        {
            var pets = await _petStoreService.GetPetsByType(type);
            return Ok(pets);
        }

        [HttpPost("AdoptPet")]
        public async Task AdoptPet([FromBody] Guid petId)
        {
            await _petStoreService.AdoptPet(petId);
        }
    }
}
