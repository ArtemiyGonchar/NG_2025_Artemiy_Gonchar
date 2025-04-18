using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;
using SentinelAbstraction.Settings;
using SentinelBusinessLayer.Clients;

namespace SentinelBusinessLayer.Injections;
public static class RefitInjections
{
    //private static readonly TreatmentClientSettings _treatmentSettings; //*
    //private static TreatmentClientSettings _treatmentSettings;
    /*public static void AddRefitClients(
        this IServiceCollection services,
        IConfiguration configuration,
        IOptions<TreatmentClientSettings> treatmentOptions)
    */
    public static void AddRefitClients(
    this IServiceCollection services,
    IConfiguration configuration,
    IOptions<TreatmentClientSettings> treatmentOptions,
    IOptions<PetStoreClientSettings> petStoreOptions,
    IOptions<StoreManagmentClientSettings> storeManagmentOptions)


    {
        //_treatmentSettings = treatmentOptions.Value ?? throw new ArgumentNullException(nameof(treatmentOptions)); //*
        //_treatmentSettings = treatmentOptions.Value;

        services.AddRefitClient<ITreatmentClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7037"));
        //
        services.AddRefitClient<IPetStoreClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7171"));

        services.AddRefitClient<IStoreManagmentClient>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7011"));
        //use Options<T> to automatically assign configs to settings
    }
}
