using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Services;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services
    .AddPooledDbContextFactory<CareerCloudContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("JOB_PORTAL")))
    .AddSingleton<IDataRepositoryFactory, EFRepositoryFactory>()
    .AddSingleton(typeof(IDataRepository<>), typeof(EFGenericRepository<>))
    .AddSingleton<BaseLogic<SecurityLoginPoco>, SecurityLoginLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<SecurityLoginService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
