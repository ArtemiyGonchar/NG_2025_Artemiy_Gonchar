using DAL_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentDAL.Repositories.Interfaces
{
    public interface IStoreRepository : IRepository<Store>
    {
        Task<List<Pet>> GetStorePets(Guid storeId);
    }
}
