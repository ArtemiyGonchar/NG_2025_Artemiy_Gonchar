using Microsoft.Extensions.Options;
using Refit;
using SentinelAbstraction.Settings;
using SentinelBusinessLayer.Injections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TreatmentClientSettings>(builder.Configuration.GetSection("RefitClients").GetSection(TreatmentClientSettings.SectionName));
builder.Services.Configure<PetStoreClientSettings>(builder.Configuration.GetSection("RefitClients").GetSection(PetStoreClientSettings.SectionName));
builder.Services.Configure<StoreManagmentClientSettings>(builder.Configuration.GetSection("RefitClients").GetSection(StoreManagmentClientSettings.SectionName));
builder.Services.AddRefitClients(
    builder.Configuration,
    Options.Create(
        builder.Configuration.GetSection("RefitClients")
            .GetSection(TreatmentClientSettings.SectionName)
            .Get<TreatmentClientSettings>() ?? new TreatmentClientSettings()
    ),
    Options.Create(
        builder.Configuration.GetSection("RefitClients")
            .GetSection(PetStoreClientSettings.SectionName)
            .Get<PetStoreClientSettings>() ?? new PetStoreClientSettings()
    ),
        Options.Create(
        builder.Configuration.GetSection("RefitClients")
            .GetSection(StoreManagmentClientSettings.SectionName)
            .Get<StoreManagmentClientSettings>() ?? new StoreManagmentClientSettings()
    )
    );

//builder.Services.AddRefitClients(builder.Configuration);
builder.Services.AddSentinelServices();

//builder.Services.Configure<TreatmentClientSettings>(builder.Configuration.GetSection("RefitClients").GetSection(TreatmentClientSettings.SectionName));
//builder.Services.Configure<PetStoreClientSettings>(builder.Configuration.GetSection("RefitClients").GetSection(PetStoreClientSettings.SectionName)); ?????????????

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
