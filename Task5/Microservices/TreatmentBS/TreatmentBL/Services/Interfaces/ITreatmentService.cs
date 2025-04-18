using DAL_Core.Entities;
using TreatmentBL.Models;

namespace TreatmentBL.Services.Interfaces;
public interface ITreatmentService
{
    Task<bool> GetTreatmentStatus(Guid id);

    Task<TreatmentDto> GetTreatment(Guid id);

    Task<List<TreatmentDto>> GetAllTreatments();

    Task<Guid> AddNewTreatment(TreatmentDto treatment);

    Task<Guid> UpdateHealthCareRecord(Guid id, TreatmentDto treatmentDto);

    Task DeleteHealthCareRecord(Guid id);
    Task<HealthCare?> GetHealthCareRecordsByPet(Guid petId);

    Task<HealthCare?> GetHealthCareRecordsByVendor(Guid petId);
}
