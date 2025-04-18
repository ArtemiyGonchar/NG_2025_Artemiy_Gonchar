using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentinelBusinessLayer.Service.Interface
{
    public interface IStoreManagmentService
    {
        Task<Guid> CreateStore(StoreDto storeDto);
        Task<Guid> UpdateStore(Guid id, StoreDto storeDto);
        Task<List<StoreDto>> GetAllStores();
        Task<List<PetDto>> GetStorePets(Guid storeId);
        Task<Guid> CreateVendor(VendorDto vendorDto);
        Task<Guid> UpdateVendor(Guid vendorId, VendorDto vendorDto);
        Task<List<VendorDto>> GetAllVendors();
        Task<VendorDto> GetVendorById(Guid vendorId);
        Task<List<VendorDto>> GetVendorsByContractType(ContractTypeBL contractType);
        Task DeleteVendor(Guid vendorId);
    }
}
