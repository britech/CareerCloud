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
    .AddPooledDbContextFactory<CareerCloudContext>(options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("JOB_PORTAL"))
        .LogTo(Console.WriteLine))
    .AddSingleton<IDataRepositoryFactory, EFRepositoryFactory>()
    .AddSingleton(typeof(IDataRepository<>), typeof(EFGenericRepository<>))
    .AddSingleton<BaseLogic<SecurityLoginPoco>, SecurityLoginLogic>()
    .AddSingleton<BaseLogic<SecurityLoginsLogPoco>, SecurityLoginsLogLogic>()
    .AddSingleton<AbstractValidatedPocoCRUDService<SystemLanguageCodePoco, string>, SystemLanguageCodeLogic>()
    .AddSingleton<BaseLogic<ApplicantEducationPoco>, ApplicantEducationLogic>()
    .AddSingleton<BaseLogic<ApplicantJobApplicationPoco>, ApplicantJobApplicationLogic>()
    .AddSingleton<BaseLogic<ApplicantProfilePoco>, ApplicantProfileLogic>()
    .AddSingleton<BaseLogic<CompanyDescriptionPoco>, CompanyDescriptionLogic>()
    .AddSingleton<BaseLogic<CompanyJobPoco>, CompanyJobLogic>()
    .AddSingleton<BaseLogic<CompanyJobEducationPoco>, CompanyJobEducationLogic>();

var app = builder.Build();

app.MapGrpcService<SecurityLoginService>();
app.MapGrpcService<SecurityLoginsLogService>();
app.MapGrpcService<SystemLanguageCodeService>();
app.MapGrpcService<ApplicantEducationService>();
app.MapGrpcService<ApplicantJobApplicationService>();
app.MapGrpcService<ApplicantProfileService>();
app.MapGrpcService<CompanyDescriptionService>();
app.MapGrpcService<CompanyJobService>();
app.MapGrpcService<CompanyJobEducationService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
