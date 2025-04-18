using Microsoft.AspNetCore.Mvc;
using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service;
using SentinelBusinessLayer.Service.Interface;

namespace Sentinel.Controllers; //
                                //{
[Route("api/[controller]")]
[Controller]
public class PetStoreController : ControllerBase
{
    private readonly IPetStoreService _petStoreService;

    public PetStoreController(IPetStoreService petStoreService)
    {
        _petStoreService = petStoreService;
    }

    [HttpPost("AddPet")]
    public async Task<IActionResult> AddPet(PetDto pet)
    {
        var petId = await _petStoreService.AddPet(pet);
        return Ok(petId);
    }

    [HttpPost("AdoptPet")]
    public async Task AdoptPet(Guid petId)
    {
        await _petStoreService.AdoptPet(petId);
        return;
    }

    [HttpGet("GetAllPets")]
    public async Task<IActionResult> GetAllPets()
    {
        var pets = await _petStoreService.GetAllPets();
        return Ok(pets);
    }

    [HttpPost("GetPetById")]
    public async Task<IActionResult> GetPetById(Guid id)
    {
        var pet = await _petStoreService.GetPetById(id);
        return Ok(pet);
    }

    [HttpPost("GetPetsByStore")]
    public async Task<IActionResult> GetPetsByStore(Guid storeId)
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
}
//}
