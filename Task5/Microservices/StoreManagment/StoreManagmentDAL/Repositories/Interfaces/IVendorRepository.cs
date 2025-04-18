using DAL_Core.Entities;
using DAL_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentDAL.Repositories.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<List<Vendor>> GetVendorsByContractType(ContractType type);
    }
}
