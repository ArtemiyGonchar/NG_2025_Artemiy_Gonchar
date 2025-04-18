using Microsoft.Extensions.DependencyInjection;
using PetStoreBL.Profiles;
using PetStoreBL.Services;
using PetStoreBL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreBL
{
    public static class PetStoreBLLInjection
    {
        public static void AddPetStoreBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IPetStoreService, PetStoreService>();

            services.AddAutoMapper(typeof(PetStoreMappingProfile));
        }
    }
}
