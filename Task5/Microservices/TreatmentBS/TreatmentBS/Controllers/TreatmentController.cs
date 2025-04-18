using DAL_Core.Entities;
using Microsoft.AspNetCore.Mvc;
using TreatmentBL.Models;
using TreatmentBL.Services.Interfaces;

namespace TreatmentBS.Controllers;

[Route("api/[controller]")]
[ApiController]
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

    [HttpPost("AddHealthCareRecord")]
    public async Task<IActionResult> AddHealthCareRecord([FromBody] TreatmentDto treatmentDto)
    {
        var treatmentId = await _treatmentService.AddNewTreatment(treatmentDto);
        return Ok(treatmentId);
    }

    [HttpPost("GetTreatmentStatus")]
    public async Task<IActionResult> GetTreatmentStatus([FromBody] Guid id)
    {
        var isExpired = await _treatmentService.GetTreatmentStatus(id);
        return Ok(isExpired);
    }

    [HttpPost("GetTreatment")]
    public async Task<IActionResult> GetTreatment([FromBody] Guid id)
    {
        var treatment = await _treatmentService.GetTreatment(id);
        return Ok(treatment);
    }

    [HttpPost("UpdateHealthCareRecord")]
    public async Task<IActionResult> UpdateHealthCareRecord([FromQuery] Guid id, TreatmentDto treatmentDto)
    {
        var updatedTreatmentId = await _treatmentService.UpdateHealthCareRecord(id, treatmentDto);
        return Ok(updatedTreatmentId);
    }

    [HttpPost("DeleteHealthCareRecord")]
    public async Task<IActionResult> DeleteHealthCareRecord([FromBody] Guid id)
    {
        await _treatmentService.DeleteHealthCareRecord(id);
        return Ok();
    }

    [HttpPost("GetHealthCareRecordsByPet")]
    public async Task<IActionResult> GetHealthCareRecordsByPet([FromBody] Guid petId)
    {
        var treatment = await _treatmentService.GetHealthCareRecordsByPet(petId);
        return Ok(treatment);
    }

    [HttpPost("GetHealthCareRecordsByVendor")]
    public async Task<IActionResult> GetHealthCareRecordsByVendor([FromBody] Guid petId)
    {
        var treatment = await _treatmentService.GetHealthCareRecordsByVendor(petId);
        return Ok(treatment);
    }

}
