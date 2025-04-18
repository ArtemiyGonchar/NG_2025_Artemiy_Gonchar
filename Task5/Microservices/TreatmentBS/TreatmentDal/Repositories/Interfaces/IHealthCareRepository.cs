using DAL_Core.Entities;

namespace TreatmentDal.Repositories.Interfaces;
public interface IHealthCareRepository : IRepository<HealthCare>
{
    Task<HealthCare?> GetHealthCareWithDetails(Guid id);
    //Task<HealthCare> AddHealthCareRecord(HealthCare healthCare);
    Task<HealthCare?> GetHealthCareRecordsByPet(Guid petId);
    Task<HealthCare?> GetHealthCareRecordsByVendor(Guid vendorId);
}
