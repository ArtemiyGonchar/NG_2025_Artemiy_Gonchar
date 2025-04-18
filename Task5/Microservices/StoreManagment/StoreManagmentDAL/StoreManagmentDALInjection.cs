using DAL_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreManagmentDAL.Repositories;
using StoreManagmentDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentDAL
{
    public static class StoreManagmentDALInjection
    {
        public static void AddStoreManagmentDALLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PetStoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
