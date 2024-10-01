using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Services;

public class CareerCloudServiceFactory : BusinessLogicFactory
{
    public CareerCloudServiceFactory(IDataRepositoryFactory factory)
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

    public static class Default
    {
        private static readonly Lazy<CareerCloudServiceFactory> _instance = new(() => new CareerCloudServiceFactory(EFRepositoryFactory.Default.Instance));

        public static CareerCloudServiceFactory Instance { get { return _instance.Value; } }
    }
}
