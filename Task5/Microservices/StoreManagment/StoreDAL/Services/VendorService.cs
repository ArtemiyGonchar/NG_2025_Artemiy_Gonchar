using AutoMapper;
using DAL_Core.Entities;
using DAL_Core.Enums;
using StoreManagmentBL.Enums;
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
    public class VendorService : IVendorService
    {
        public readonly IVendorRepository _vendorRepository;
        public readonly IMapper _mapper;

        public VendorService(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateVendor(VendorDto vendorDto)
        {
            var vendor = _mapper.Map<Vendor>(vendorDto);

            await _vendorRepository.CreateAsync(vendor);
            return vendor.Id;
        }

        public async Task<Guid> UpdateVendor(Guid vendorId, VendorDto vendorDto)
        {
            var vendorFromDto = _mapper.Map<Vendor>(vendorDto);

            var vendor = await _vendorRepository.GetAsync(vendorId);

            vendor.Name = vendorFromDto.Name;
            vendor.Description = vendorFromDto.Description;
            vendor.SignedAt = vendorFromDto.SignedAt;
            vendor.ExpirationDate = vendorFromDto.ExpirationDate;
            vendor.ContractType = vendorFromDto.ContractType;

            var vendorid = await _vendorRepository.UpdateAsync(vendor);
            return vendorid;
        }

        public async Task<List<VendorDto>> GetAllVendors()
        {
            var vendors = await _vendorRepository.GetAllAsync();
            var vendorsDto = _mapper.Map<List<VendorDto>>(vendors);
            return vendorsDto;
        }

        public async Task<VendorDto> GetVendorById(Guid vendorId)
        {
            var vendor = await _vendorRepository.GetAsync(vendorId);
            var vendorDto = _mapper.Map<VendorDto>(vendor);
            return vendorDto;
        }

        public async Task<List<VendorDto>> GetVendorsByContractType(ContractTypeBL contractType)
        {
            var typeDAL = _mapper.Map<ContractType>(contractType);
            var vendors = await _vendorRepository.GetVendorsByContractType(typeDAL);
            var vendorDtoList = _mapper.Map<List<VendorDto>>(vendors);
            return vendorDtoList;
        }

        public async Task DeleteVendor(Guid vendorId)
        {
            await _vendorRepository.DeleteAsync(vendorId);
            return;
        }
    }
}
