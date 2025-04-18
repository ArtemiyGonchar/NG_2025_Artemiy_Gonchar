using DAL_Core;
using DAL_Core.Entities;
using Microsoft.EntityFrameworkCore;
using StoreManagmentDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentDAL.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private readonly PetStoreDbContext _ctx;

        public StoreRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Pet>> GetStorePets(Guid storeId)
        {
            var pets = await _ctx.Pets.Where(s => s.StoreId == storeId).ToListAsync();
            return pets;
        }
    }
}
