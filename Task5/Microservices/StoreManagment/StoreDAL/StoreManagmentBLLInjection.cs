using Microsoft.Extensions.DependencyInjection;
using StoreManagmentBL.Profiles;
using StoreManagmentBL.Services;
using StoreManagmentBL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagmentBL
{
    public static class StoreManagmentBLLInjection
    {
        public static void AddStoreManagmentBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddAutoMapper(typeof(StoreManagmentMappingProfile));
        }
    }
}
