using DAL_Core.Entities;
using DAL_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreDAL.Repositories.Interfaces
{
    public interface IPetRepository : IRepository<Pet>
    {
        Task<Pet> AddPet(Pet pet);
        Task<List<Pet>> GetPetsByStore(Guid storeId);
        Task<List<Pet>> GetPetsByType(PetTypes types);
    }
}
