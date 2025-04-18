using StoreManagmentBL.Enums;
using StoreManagmentBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentBL.Services.Interfaces
{
    public interface IVendorService
    {
        Task<Guid> CreateVendor(VendorDto vendorDto);
        Task<Guid> UpdateVendor(Guid vendorId, VendorDto vendorDto);
        Task<List<VendorDto>> GetAllVendors();
        Task<VendorDto> GetVendorById(Guid vendorId);
        Task<List<VendorDto>> GetVendorsByContractType(ContractTypeBL contractType);
        Task DeleteVendor(Guid vendorId);
    }
}
