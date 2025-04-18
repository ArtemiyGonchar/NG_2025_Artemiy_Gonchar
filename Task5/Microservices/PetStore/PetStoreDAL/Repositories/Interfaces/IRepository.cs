using DAL_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreDAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetAsync(Guid id);
        Task<Guid> CreateAsync(T entity);
        Task<Guid> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
