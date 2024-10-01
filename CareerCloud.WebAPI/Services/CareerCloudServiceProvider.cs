using CareerCloud.BusinessLogicLayer;
using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Services;

public class CareerCloudServiceProvider : TypeAwareServiceFactory
{
    private static readonly Lazy<CareerCloudServiceProvider> _instance = new(() => new CareerCloudServiceProvider(new EFRepositoryFactory(new CareerCloudContextFactory(new CareerCloudConfigResolver(DefaultConfigurationLoader.Instance.Configuration)))));

    public static CareerCloudServiceProvider Instance { get { return _instance.Value; } }

    private CareerCloudServiceProvider(TypeAwareRepositoryFactory factory)
    {
        RegisterService(new ApplicantEducationLogic(factory.GetRepository<ApplicantEducationPoco>()));
        RegisterService(new ApplicantJobApplicationLogic(factory.GetRepository<ApplicantJobApplicationPoco>()));
        RegisterService(new ApplicantProfileLogic(factory.GetRepository<ApplicantProfilePoco>()));
        RegisterService(new ApplicantResumeLogic(factory.GetRepository<ApplicantResumePoco>()));
        RegisterService(new ApplicantSkillLogic(factory.GetRepository<ApplicantSkillPoco>()));
        RegisterService(new ApplicantWorkHistoryLogic(factory.GetRepository<ApplicantWorkHistoryPoco>()));
        RegisterService(new CompanyDescriptionLogic(factory.GetRepository<CompanyDescriptionPoco>()));
        RegisterService(new CompanyJobDescriptionLogic(factory.GetRepository<CompanyJobDescriptionPoco>()));
        RegisterService(new CompanyJobEducationLogic(factory.GetRepository<CompanyJobEducationPoco>()));
        RegisterService(new CompanyJobLogic(factory.GetRepository<CompanyJobPoco>()));
        RegisterService(new CompanyJobSkillLogic(factory.GetRepository<CompanyJobSkillPoco>()));
        RegisterService(new CompanyLocationLogic(factory.GetRepository<CompanyLocationPoco>()));
        RegisterService(new CompanyProfileLogic(factory.GetRepository<CompanyProfilePoco>()));
        RegisterService(new SecurityLoginLogic(factory.GetRepository<SecurityLoginPoco>()));
        RegisterService(new SecurityLoginsLogLogic(factory.GetRepository<SecurityLoginsLogPoco>()));
        RegisterService(new SecurityLoginsRoleLogic(factory.GetRepository<SecurityLoginsRolePoco>()));
        RegisterService(new SecurityRoleLogic(factory.GetRepository<SecurityRolePoco>()));
        RegisterService(new SystemCountryCodeLogic(factory.GetRepository<SystemCountryCodePoco>()));
        RegisterService(new SystemLanguageCodeLogic(factory.GetRepository<SystemLanguageCodePoco>()));
    }
}
