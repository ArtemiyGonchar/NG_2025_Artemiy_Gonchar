using Microsoft.AspNetCore.Mvc;
using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Enums;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;

namespace Sentinel.Controllers;

[Route("api/[controller]")]
[Controller]
public class StoreManagmentController : ControllerBase
{
    private readonly IStoreManagmentService _storeManagmentService;

    public StoreManagmentController(IStoreManagmentService storeManagmentService)
    {
        _storeManagmentService = storeManagmentService;
    }
    [HttpPost("CreateStore")]
    public async Task<IActionResult> CreateStore([FromBody] StoreDto storeDto)
    {
        var storeId = await _storeManagmentService.CreateStore(storeDto);
        return Ok(storeId);
    }
    [HttpPost("CreateVendor")]
    public async Task<IActionResult> CreateVendor([FromBody] VendorDto vendorDto)
    {
        var vendorId = await _storeManagmentService.CreateVendor(vendorDto);
        return Ok(vendorId);
    }
    [HttpPost("DeleteVendor")]
    public async Task DeleteVendor([FromBody] Guid vendorId)
    {
        await _storeManagmentService.DeleteVendor(vendorId);
        return;
    }
    [HttpGet("GetAllStores")]
    public async Task<IActionResult> GetAllStores()
    {
        var stores = await _storeManagmentService.GetAllStores();
        return Ok(stores);
    }
    [HttpGet("GetAllVendors")]
    public async Task<IActionResult> GetAllVendors()
    {
        var vendors = await _storeManagmentService.GetAllVendors();
        return Ok(vendors);
    }
    [HttpPost("GetStorePets")]
    public async Task<IActionResult> GetStorePets([FromBody] Guid storeId)
    {
        var storePets = await _storeManagmentService.GetStorePets(storeId);
        return Ok(storePets);
    }
    [HttpPost("GetVendorById")]
    public async Task<IActionResult> GetVendorById([FromBody] Guid vendorId)
    {
        var vendor = await _storeManagmentService.GetVendorById(vendorId);
        return Ok(vendor);
    }
    [HttpPost("GetVendorsByContractType")]
    public async Task<IActionResult> GetVendorsByContractType([FromBody] ContractTypeBL contractType)
    {
        var vendors = await _storeManagmentService.GetVendorsByContractType(contractType);
        return Ok(vendors);
    }
    [HttpPost("UpdateStore")]
    public async Task<IActionResult> UpdateStore([FromQuery] Guid id, StoreDto storeDto)
    {
        var storeId = await _storeManagmentService.UpdateStore(id, storeDto);
        return Ok(storeId);
    }
    [HttpPost("UpdateVendor")]
    public async Task<IActionResult> UpdateVendor([FromBody] Guid vendorId, VendorDto vendorDto)
    {
        var vendor = await _storeManagmentService.UpdateVendor(vendorId, vendorDto);
        return Ok(vendor);

    }
}

