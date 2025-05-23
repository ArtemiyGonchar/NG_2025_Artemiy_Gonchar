﻿using Microsoft.Extensions.DependencyInjection;
using SentinelBusinessLayer.Clients;
using SentinelBusinessLayer.Service;
using SentinelBusinessLayer.Service.Interface;

namespace SentinelBusinessLayer.Injections;
public static class BusinessLayerInjection
{
    public static void AddSentinelServices(this IServiceCollection services)
    {
        services.AddScoped<ITreatmentService, TreatmentService>();
        services.AddScoped<IPetStoreService, PetStoreService>();
        services.AddScoped<IStoreManagmentService, StoreManagmentService>();
    }
}
