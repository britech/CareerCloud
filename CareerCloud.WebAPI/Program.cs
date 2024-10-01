using CareerCloud.BusinessLogicLayer;
using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Configuration.Sources.Clear();
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddSingleton<ICareerCloudConfigResolver, CareerCloudConfigResolver>()
    .AddPooledDbContextFactory<CareerCloudContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("JOB_PORTAL")))
    .AddSingleton<TypeAwareRepositoryFactory, EFRepositoryFactory>()
    .AddSingleton(typeof(IDataRepository<>), typeof(EFGenericRepository<>))
    .AddSingleton<AbstractValidatedPocoCRUDService<SystemCountryCodePoco, string>, SystemCountryCodeLogic>();

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
