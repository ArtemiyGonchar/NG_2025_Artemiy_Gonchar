using Microsoft.AspNetCore.Mvc;
using Refit;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;

namespace Sentinel.Controllers;

[Route("api/[controller]")]
[Controller]
public class TreatmentController : ControllerBase
{
    private readonly ITreatmentService _treatmentService;

    public TreatmentController(ITreatmentService treatmentService)
    {
        _treatmentService = treatmentService;
    }

    [HttpGet("GetAllTreatments")]
    public async Task<IActionResult> GetAllTreatments()
    {
        var treatments = await _treatmentService.GetAllTreatments();

        return Ok(treatments);
    }

    [HttpPost("GetTreatment")]
    public async Task<IActionResult> GetTreatment([FromBody] Guid id)
    {
        var treatment = await _treatmentService.GetTreatment(id);
        return Ok(treatment);
    }

    [HttpPost("AddHealthCareRecord")]
    public async Task<IActionResult> AddHealthCareRecord([FromBody] TreatmentDto treatmentDto)
    {
        var treatmentId = await _treatmentService.AddNewTreatment(treatmentDto);
        return Ok(treatmentId);
    }

    [HttpPost("GetHealthCareRecordsByPets")]
    public async Task<IActionResult> GetHealthCareRecordsByPet([FromBody] Guid petId)
    {
        var treatment = await _treatmentService.GetHealthCareRecordsByPet(petId);
        return Ok(treatment);
    }

    [HttpPost("GetTreatmentStatus")]
    public async Task<IActionResult> GetTreatmentStatus([FromBody] Guid id)
    {
        var treatmentStatus = await _treatmentService.GetTreatmentStatus(id);
        return Ok(treatmentStatus);
    }

    [HttpPost("GetHealthCareRecordsByVendor")]
    public async Task<IActionResult> GetHealthCareRecordsByVendor([FromBody] Guid petId)
    {
        var treatmentStatus = await _treatmentService.GetHealthCareRecordsByVendor(petId);
        return Ok(treatmentStatus);
    }

    [HttpPost("DeleteHealthCareRecord")]
    public async Task<IActionResult> DeleteHealthCareRecord([FromBody] Guid id)
    {
        await _treatmentService.DeleteHealthCareRecord(id);
        return Ok();
    }

    [HttpPost("UpdateHealthCareRecord")]
    public async Task<IActionResult> UpdateHealthCareRecord([FromBody] Guid id, TreatmentDto treatmentDto)
    {
        var treatmentId = await _treatmentService.UpdateHealthCareRecord(id, treatmentDto);
        return Ok(treatmentId);
    }
}
