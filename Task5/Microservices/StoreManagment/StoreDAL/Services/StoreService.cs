using AutoMapper;
using DAL_Core.Entities;
using StoreManagmentBL.Models;
using StoreManagmentBL.Services.Interfaces;
using StoreManagmentDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentBL.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateStore(StoreDto storeDto)
        {
            if (string.IsNullOrEmpty(storeDto.Name))
            {
                throw new ArgumentNullException("Store name is empty");
            }

            if (string.IsNullOrEmpty(storeDto.City))
            {
                throw new ArgumentNullException("Store city is empty");
            }

            var storeDAL = _mapper.Map<Store>(storeDto);
            var storeCreated = await _storeRepository.CreateAsync(storeDAL);
            return storeCreated;
        }

        public async Task<Guid> UpdateStore(Guid id, StoreDto storeDto)
        {
            var storeFromDto = _mapper.Map<Store>(storeDto);

            var store = await _storeRepository.GetAsync(id);

            store.Name = storeDto.Name;
            store.Description = storeDto.Description;
            store.City = storeDto.City;
            store.Address = storeDto.Address;

            var storeId = await _storeRepository.UpdateAsync(store);
            return storeId;
        }

        public async Task<List<StoreDto>> GetAllStores()
        {
            var stores = await _storeRepository.GetAllAsync();
            return _mapper.Map<List<StoreDto>>(stores);
        }

        public async Task<List<PetDto>> GetStorePets(Guid storeId)
        {
            var pets = await _storeRepository.GetStorePets(storeId);
            var petsDto = _mapper.Map<List<PetDto>>(pets);
            return petsDto;
        }
    }
}
