using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFRepositoryRegistry : TypeAwareRepositoryRegistry
    {
        public EFRepositoryRegistry(IDbContextFactory<CareerCloudContext> dbContextFactory) : base() {
            RegisterRepository(typeof(ApplicantEducationPoco), new ApplicantEducationRepository(dbContextFactory));
            RegisterRepository(typeof(ApplicantJobApplicationPoco), new ApplicantJobApplicationRepository(dbContextFactory));
            RegisterRepository(typeof(ApplicantProfilePoco), new ApplicantProfileRepository(dbContextFactory));
            RegisterRepository(typeof(ApplicantResumePoco), new ApplicantResumeRepository(dbContextFactory));
            RegisterRepository(typeof(ApplicantSkillPoco), new ApplicantSkillRepository(dbContextFactory));
            RegisterRepository(typeof(ApplicantWorkHistoryPoco), new ApplicantWorkHistoryRepository(dbContextFactory));
            RegisterRepository(typeof(CompanyDescriptionPoco), new CompanyDescriptionRepository(dbContextFactory));
            RegisterRepository(typeof(CompanyJobDescriptionPoco), new CompanyJobDescriptionRepository(dbContextFactory));
            RegisterRepository(typeof(CompanyJobEducationPoco), new CompanyJobEducationRepository(dbContextFactory));
            RegisterRepository(typeof(CompanyJobPoco), new CompanyJobRepository(dbContextFactory));
            RegisterRepository(typeof(CompanyJobSkillPoco), new CompanyJobSkillRepository(dbContextFactory));
            RegisterRepository(typeof(CompanyLocationPoco), new CompanyLocationRepository(dbContextFactory));
            RegisterRepository(typeof(CompanyProfilePoco), new CompanyProfileRepository(dbContextFactory));
            RegisterRepository(typeof(SecurityLoginPoco), new SecurityLoginRepository(dbContextFactory));
            RegisterRepository(typeof(SecurityLoginsLogPoco), new SecurityLoginsLogRepository(dbContextFactory));
            RegisterRepository(typeof(SecurityLoginsRolePoco), new SecurityLoginsRoleRepository(dbContextFactory));
            RegisterRepository(typeof(SecurityRolePoco), new SecurityRoleRepository(dbContextFactory));
            RegisterRepository(typeof(SystemCountryCodePoco), new SystemCountryCodeRepository(dbContextFactory));
            RegisterRepository(typeof(SystemLanguageCodePoco), new SystemLanguageCodeRepository(dbContextFactory));
        }
    }
}
