using AutoMapper;
using DAL_Core.Entities;
using DAL_Core.Enums;
using PetStoreBL.Enums;
using PetStoreBL.Models;
using PetStoreBL.Services.Interfaces;
using PetStoreDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreBL.Services
{
    public class PetStoreService : IPetStoreService
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PetStoreService(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddPet(PetStoreDto pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                throw new ArgumentNullException("Pet name is empty");
            }

            if (string.IsNullOrEmpty(pet.Breed))
            {
                throw new ArgumentNullException("Pet breed is empty");
            }

            var petDAL = _mapper.Map<Pet>(pet);
            var petCreated = await _petRepository.AddPet(petDAL);
            return _mapper.Map<PetStoreDto>(petCreated).Id;
        }

        public async Task<PetStoreDto> GetPetById(Guid id)
        {
            var pet = await _petRepository.GetAsync(id);
            var petStoreDto = _mapper.Map<PetStoreDto>(pet);
            return petStoreDto;
        }

        public async Task<List<PetStoreDto>> GetAllPets()
        {
            var petList = await _petRepository.GetAllAsync();
            var petStoreDtoList = _mapper.Map<List<PetStoreDto>>(petList);
            return petStoreDtoList;
        }

        public async Task<List<PetStoreDto>> GetPetsByStore(Guid storeId)
        {
            var pets = await _petRepository.GetPetsByStore(storeId);
            var petStoreDtoList = _mapper.Map<List<PetStoreDto>>(pets);
            return petStoreDtoList;
        }

        public async Task<List<PetStoreDto>> GetPetsByType(PetTypesBL type)
        {
            var typeDAL = _mapper.Map<PetTypes>(type);
            var pets = await _petRepository.GetPetsByType(typeDAL);
            var petStoreDtoList = _mapper.Map<List<PetStoreDto>>(pets);
            return petStoreDtoList;
        }

        public async Task AdoptPet(Guid petId)
        {
            await _petRepository.DeleteAsync(petId);
        }
    }
}
