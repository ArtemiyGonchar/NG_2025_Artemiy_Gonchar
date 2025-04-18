using Refit;
using SentinelBusinessLayer.Models;

namespace SentinelBusinessLayer.Clients;
public interface ITreatmentClient
{
    [Get("/api/treatment/GetAllTreatments")]
    Task<List<TreatmentDto>> GetAllTreatments();

    [Post("/api/treatment/GetTreatment")]
    Task<TreatmentDto> GetTreatment([Body] Guid id);

    [Post("/api/treatment/AddHealthCareRecord")]
    Task<Guid> AddNewTreatment([Body] TreatmentDto treatment);

    [Post("/api/treatment/GetHealthCareRecordsByPet")]
    Task<TreatmentDto?> GetHealthCareRecordsByPet([Body] Guid petId);

    [Post("/api/treatment/GetTreatmentStatus")]
    Task<bool> GetTreatmentStatus([Body] Guid id);

    [Post("/api/treatment/GetHealthCareRecordsByVendor")]
    Task<TreatmentDto?> GetHealthCareRecordsByVendor([Body] Guid petId);

    [Post("/api/treatment/DeleteHealthCareRecord")]
    Task DeleteHealthCareRecord([Body] Guid id);

    [Post("/api/treatment/UpdateHealthCareRecord")]
    Task<Guid> UpdateHealthCareRecord([Body] Guid id, TreatmentDto treatmentDto);
}
