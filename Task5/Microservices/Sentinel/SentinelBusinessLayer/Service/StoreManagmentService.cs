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
    public class StoreManagmentService : IStoreManagmentService
    {
        private readonly IStoreManagmentClient _storeManagmentClient;

        public StoreManagmentService(IStoreManagmentClient storeManagmentClient)
        {
            _storeManagmentClient = storeManagmentClient;
        }

        public async Task<Guid> CreateStore(StoreDto storeDto)
        {
            return await _storeManagmentClient.CreateStore(storeDto);
        }

        public async Task<Guid> CreateVendor(VendorDto vendorDto)
        {
            return await _storeManagmentClient.CreateVendor(vendorDto);
        }

        public async Task DeleteVendor(Guid vendorId)
        {
            await _storeManagmentClient.DeleteVendor(vendorId);
            return;
        }

        public async Task<List<StoreDto>> GetAllStores()
        {
            return await _storeManagmentClient.GetAllStores();
        }

        public async Task<List<VendorDto>> GetAllVendors()
        {
            return await _storeManagmentClient.GetAllVendors();
        }

        public async Task<List<PetDto>> GetStorePets(Guid storeId)
        {
            return await _storeManagmentClient.GetStorePets(storeId);
        }

        public async Task<VendorDto> GetVendorById(Guid vendorId)
        {
            return await _storeManagmentClient.GetVendorById(vendorId);
        }

        public async Task<List<VendorDto>> GetVendorsByContractType(ContractTypeBL contractType)
        {
            return await _storeManagmentClient.GetVendorsByContractType(contractType);
        }

        public async Task<Guid> UpdateStore(Guid id, StoreDto storeDto)
        {
            return await _storeManagmentClient.UpdateStore(id, storeDto);
        }

        public async Task<Guid> UpdateVendor(Guid vendorId, VendorDto vendorDto)
        {
            return await _storeManagmentClient.UpdateVendor(vendorId, vendorDto);
        }
    }
}
