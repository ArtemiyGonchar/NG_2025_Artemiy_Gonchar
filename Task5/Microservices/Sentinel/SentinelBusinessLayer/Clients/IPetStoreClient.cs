using Refit;
using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Clients
{
    public interface IPetStoreClient
    {
        [Post("/api/petstore/AddPet")]
        Task<Guid> AddPet([Body] PetDto pet);

        [Post("/api/petstore/GetPetById")]
        Task<PetDto> GetPetById([Body] Guid id);

        [Get("/api/PetStore/GetAllPets")]
        Task<List<PetDto>> GetAllPets();

        [Post("/api/petstore/GetPetsByStore")]
        Task<List<PetDto>> GetPetsByStore([Body] Guid storeId);

        [Post("/api/petstore/GetPetsByType")]
        Task<List<PetDto>> GetPetsByType([Body] PetTypesBL type);

        [Post("/api/petstore/AdoptPet")]
        Task AdoptPet([Body] Guid petId);

    }
}
