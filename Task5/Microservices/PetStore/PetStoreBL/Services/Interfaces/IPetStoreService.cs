using PetStoreBL.Enums;
using PetStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreBL.Services.Interfaces
{
    public interface IPetStoreService
    {
        Task<Guid> AddPet(PetStoreDto pet);
        Task<PetStoreDto> GetPetById(Guid id);
        Task<List<PetStoreDto>> GetAllPets();
        Task<List<PetStoreDto>> GetPetsByStore(Guid storeId);
        Task<List<PetStoreDto>> GetPetsByType(PetTypesBL type);
        Task AdoptPet(Guid petId);

    }
}
