using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
    .AddSingleton(typeof(IDataRepository<>), typeof(EFGenericRepository<>))
    .AddSingleton<BaseLogic<ApplicantEducationPoco>, ApplicantEducationLogic>()
    .AddSingleton<BaseLogic<ApplicantJobApplicationPoco>, ApplicantJobApplicationLogic>()
    .AddSingleton<BaseLogic<ApplicantProfilePoco>, ApplicantProfileLogic>()
    .AddSingleton<BaseLogic<ApplicantResumePoco>, ApplicantResumeLogic>()
    .AddSingleton<BaseLogic<ApplicantWorkHistoryPoco>, ApplicantWorkHistoryLogic>()
    .AddSingleton<BaseLogic<CompanyDescriptionPoco>, CompanyDescriptionLogic>()
    .AddSingleton<BaseLogic<CompanyJobPoco>, CompanyJobLogic>()
    .AddSingleton<BaseLogic<CompanyJobEducationPoco>, CompanyJobEducationLogic>()
    .AddSingleton<BaseLogic<CompanyJobDescriptionPoco>, CompanyJobDescriptionLogic>()
    .AddSingleton<BaseLogic<CompanyJobSkillPoco>, CompanyJobSkillLogic>()
    .AddSingleton<BaseLogic<CompanyLocationPoco>, CompanyLocationLogic>()
    .AddSingleton<BaseLogic<CompanyProfilePoco>, CompanyProfileLogic>()
    .AddSingleton<BaseLogic<SecurityLoginPoco>, SecurityLoginLogic>()
    .AddSingleton<BaseLogic<SecurityLoginsLogPoco>, SecurityLoginsLogLogic>()
    .AddSingleton<BaseLogic<SecurityLoginsRolePoco>, SecurityLoginsRoleLogic>()
    .AddSingleton<BaseLogic<SecurityRolePoco>, SecurityRoleLogic>()
    .AddSingleton<AbstractValidatedPocoCRUDService<SystemCountryCodePoco, string>, SystemCountryCodeLogic>()
    .AddSingleton<AbstractValidatedPocoCRUDService<SystemLanguageCodePoco, string>, SystemLanguageCodeLogic>();

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
