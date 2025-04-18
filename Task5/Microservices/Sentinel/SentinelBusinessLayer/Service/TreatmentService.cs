using Refit;
using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Models;
using SentinelBusinessLayer.Service.Interface;

namespace SentinelBusinessLayer.Service;
public class TreatmentService : ITreatmentService
{
    private readonly ITreatmentClient _treatmentClient;

    public TreatmentService(ITreatmentClient treatmentClient)
    {
        _treatmentClient = treatmentClient;
    }

    public async Task<List<TreatmentDto>> GetAllTreatments()
    {
        return await _treatmentClient.GetAllTreatments();
    }

    public async Task<TreatmentDto> GetTreatment(Guid id)
    {
        return await _treatmentClient.GetTreatment(id);
    }

    public async Task<Guid> AddNewTreatment(TreatmentDto treatment)
    {
        return await _treatmentClient.AddNewTreatment(treatment);
    }

    public async Task<TreatmentDto?> GetHealthCareRecordsByPet(Guid petId)
    {
        return await _treatmentClient.GetHealthCareRecordsByPet(petId);
    }

    public async Task<bool> GetTreatmentStatus(Guid id)
    {
        return await _treatmentClient.GetTreatmentStatus(id);
    }

    public async Task<TreatmentDto?> GetHealthCareRecordsByVendor(Guid petId)
    {
        return await _treatmentClient.GetHealthCareRecordsByVendor(petId);
    }

    public async Task DeleteHealthCareRecord(Guid id)
    {
        await _treatmentClient.DeleteHealthCareRecord(id);
        return;
    }

    public async Task<Guid> UpdateHealthCareRecord([Body] Guid id, TreatmentDto treatmentDto)
    {
        return id = await _treatmentClient.UpdateHealthCareRecord(id, treatmentDto);
    }
}
