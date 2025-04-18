using Refit;
using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service
{
    public class PetStoreService : IPetStoreService
    {
        private readonly IPetStoreClient _petStoreClient;
        public PetStoreService(IPetStoreClient petStoreClient)
        {
            _petStoreClient = petStoreClient;
        }

        public async Task<Guid> AddPet(PetDto pet)
        {
            return await _petStoreClient.AddPet(pet);
        }

        public async Task AdoptPet(Guid petId)
        {
            await _petStoreClient.AdoptPet(petId);
            return;
        }

        public async Task<List<PetDto>> GetAllPets()
        {
            return await _petStoreClient.GetAllPets();
        }

        public async Task<PetDto> GetPetById(Guid id)
        {
            return await _petStoreClient.GetPetById(id);
        }

        public async Task<List<PetDto>> GetPetsByStore(Guid storeId)
        {
            return await _petStoreClient.GetPetsByStore(storeId);
        }

        public async Task<List<PetDto>> GetPetsByType(PetTypesBL type)
        {
            return await _petStoreClient.GetPetsByType(type);
        }
    }
}
