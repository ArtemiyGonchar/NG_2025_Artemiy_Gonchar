using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service.Interface
{
    public interface IPetStoreService
    {
        Task<Guid> AddPet(PetDto pet);
        Task<PetDto> GetPetById(Guid id);
        Task<List<PetDto>> GetAllPets();
        Task<List<PetDto>> GetPetsByStore(Guid storeId);
        Task<List<PetDto>> GetPetsByType(PetTypesBL type);
        Task AdoptPet(Guid petId);
    }
}
