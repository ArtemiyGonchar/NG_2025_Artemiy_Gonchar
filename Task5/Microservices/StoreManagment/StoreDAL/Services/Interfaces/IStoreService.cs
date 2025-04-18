
using StoreManagmentBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentBL.Services.Interfaces
{
    public interface IStoreService
    {
        Task<Guid> CreateStore(StoreDto storeDto);
        Task<Guid> UpdateStore(Guid id, StoreDto storeDto);
        Task<List<StoreDto>> GetAllStores();
        Task<List<PetDto>> GetStorePets(Guid storeId);
    }
}
