using Microsoft.AspNetCore.Mvc;
using StoreManagmentBL.Enums;
using StoreManagmentBL.Models;
using StoreManagmentBL.Services.Interfaces;

namespace StoreManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpPost("CreateVendor")]
        public async Task<IActionResult> CreateVendor([FromBody] VendorDto vendorDto)
        {
            var vendorId = await _vendorService.CreateVendor(vendorDto);
            return Ok(vendorId);
        }

        [HttpPost("UpdateVendor")]
        public async Task<IActionResult> UpdateVendor([FromQuery] Guid id, VendorDto vendorDto)
        {
            var vendorId = await _vendorService.UpdateVendor(id, vendorDto);
            return Ok(vendorId);
        }

        [HttpGet("GetAllVendors")]
        public async Task<IActionResult> GetAllVendors()
        {
            var vendors = await _vendorService.GetAllVendors();
            return Ok(vendors);
        }

        [HttpPost("GetVendorById")]
        public async Task<IActionResult> GetVendorById([FromBody] Guid id)
        {
            var vendorDto = await _vendorService.GetVendorById(id);
            return Ok(vendorDto);
        }

        [HttpPost("GetVendorsByType")]
        public async Task<IActionResult> GetVendorsByType([FromBody] ContractTypeBL type)
        {
            var vendorsListDto = await _vendorService.GetVendorsByContractType(type);
            return Ok(vendorsListDto);
        }
        [HttpPost("DeleteVendors")]
        public async Task<IActionResult> DeleteVendor([FromBody] Guid vendorId)
        {
            await _vendorService.DeleteVendor(vendorId);
            return Ok();
        }
    }
}
