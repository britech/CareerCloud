using CareerCloud.BusinessLogicLayer;
using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CareerCloud API Services",
        Description = "API services for the CareerCloud application",
        Contact = new OpenApiContact
        {
            Name = "Technology Services - Solutions",
            Email = "techsvc.solutions@tempuri.com"
        },
        License = new OpenApiLicense
        {
            Name = "PROPRIETARY"
        }
    });
    options.EnableAnnotations();
});

builder.Services
    .AddPooledDbContextFactory<CareerCloudContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("JOB_PORTAL")))
    .AddSingleton<IDataRepositoryFactory, EFRepositoryFactory>()
    .AddSingleton<BusinessLogicFactory, CareerCloudServiceFactory>();

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
