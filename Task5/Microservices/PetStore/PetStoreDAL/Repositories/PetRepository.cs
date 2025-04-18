using DAL_Core;
using DAL_Core.Entities;
using DAL_Core.Enums;
using Microsoft.EntityFrameworkCore;
using PetStoreDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreDAL.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        private readonly PetStoreDbContext _ctx;
        public PetRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _ctx.Pets.Add(pet);
            await _ctx.SaveChangesAsync();
            return pet;
        }

        public async Task<List<Pet>> GetPetsByStore(Guid storeId)
        {
            var pets = await _ctx.Pets.Where(p => p.StoreId == storeId).ToListAsync();
            return pets;
        }

        public async Task<List<Pet>> GetPetsByType(PetTypes types)
        {
            var pets = await _ctx.Pets.Where(p => p.Type == types).ToListAsync();
            return pets;
        }
    }
}
