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
    public interface IStoreManagmentClient
    {
        [Post("/api/store/CreateStore")]
        Task<Guid> CreateStore([Body] StoreDto storeDto);
        [Post("/api/store/UpdateStore")]
        Task<Guid> UpdateStore([Body] Guid id, StoreDto storeDto);
        [Get("/api/store/GetAllStores")]
        Task<List<StoreDto>> GetAllStores();
        [Post("/api/store/GetStorePets")]
        Task<List<PetDto>> GetStorePets([Body] Guid storeId);

        [Post("/api/Vendor/CreateVendor")]
        Task<Guid> CreateVendor([Body] VendorDto vendorDto);
        [Post("/api/Vendor/UpdateVendor")]
        Task<Guid> UpdateVendor([Body] Guid vendorId, VendorDto vendorDto);
        [Get("/api/Vendor/GetAllVendors")]
        Task<List<VendorDto>> GetAllVendors();
        [Post("/api/Vendor/GetVendorById")]
        Task<VendorDto> GetVendorById([Body] Guid vendorId);
        [Post("/api/Vendor/GetVendorsByContractType")]
        Task<List<VendorDto>> GetVendorsByContractType([Body] ContractTypeBL contractType);
        [Post("/api/Vendor/DeleteVendor")]
        Task DeleteVendor([Body] Guid vendorId);
    }
}
