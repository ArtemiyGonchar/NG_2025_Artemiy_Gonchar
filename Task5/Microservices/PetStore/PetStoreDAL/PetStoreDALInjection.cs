using DAL_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetStoreDAL.Repositories;
using PetStoreDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreDAL
{
    public static class PetStoreDALInjection
    {
        public static void AddPetStoreDALLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PetStoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));


            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<>
        }
    }
}
