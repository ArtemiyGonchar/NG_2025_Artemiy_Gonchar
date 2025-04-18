using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Service.Interface;
public interface ITreatmentService
{
    Task<List<TreatmentDto>> GetAllTreatments();

    Task<Guid> AddNewTreatment(TreatmentDto treatment);

    Task<Guid> UpdateHealthCareRecord(Guid id, TreatmentDto treatmentDto);

    Task DeleteHealthCareRecord(Guid id);
    Task<TreatmentDto?> GetHealthCareRecordsByPet(Guid petId);
    Task<TreatmentDto?> GetHealthCareRecordsByVendor(Guid petId);
    Task<bool> GetTreatmentStatus(Guid id);
    Task<TreatmentDto> GetTreatment(Guid id);
}
