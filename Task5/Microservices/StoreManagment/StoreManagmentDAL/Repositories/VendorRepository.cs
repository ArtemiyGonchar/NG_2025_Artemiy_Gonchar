using DAL_Core;
using DAL_Core.Entities;
using DAL_Core.Enums;
using Microsoft.EntityFrameworkCore;
using StoreManagmentDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentDAL.Repositories
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        private readonly PetStoreDbContext _ctx;

        public VendorRepository(PetStoreDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Vendor>> GetVendorsByContractType(ContractType type)
        {
            var vendors = await _ctx.Vendors.Where(v => v.ContractType == type).ToListAsync();
            return vendors;
        }

    }
}
