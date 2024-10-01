using CareerCloud.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.EntityFrameworkDataAccess;

public class EFRepositoryFactory : IDataRepositoryFactory
{
    public EFRepositoryFactory(IDbContextFactory<CareerCloudContext> dbContextFactory)
    {
        RegisterRepository(new ApplicantEducationRepository(dbContextFactory));
        RegisterRepository(new ApplicantJobApplicationRepository(dbContextFactory));
        RegisterRepository(new ApplicantProfileRepository(dbContextFactory));
        RegisterRepository(new ApplicantResumeRepository(dbContextFactory));
        RegisterRepository(new ApplicantSkillRepository(dbContextFactory));
        RegisterRepository(new ApplicantWorkHistoryRepository(dbContextFactory));
        RegisterRepository(new CompanyDescriptionRepository(dbContextFactory));
        RegisterRepository(new CompanyJobDescriptionRepository(dbContextFactory));
        RegisterRepository(new CompanyJobEducationRepository(dbContextFactory));
        RegisterRepository(new CompanyJobRepository(dbContextFactory));
        RegisterRepository(new CompanyJobSkillRepository(dbContextFactory));
        RegisterRepository(new CompanyLocationRepository(dbContextFactory));
        RegisterRepository(new CompanyProfileRepository(dbContextFactory));
        RegisterRepository(new SecurityLoginRepository(dbContextFactory));
        RegisterRepository(new SecurityLoginsLogRepository(dbContextFactory));
        RegisterRepository(new SecurityLoginsRoleRepository(dbContextFactory));
        RegisterRepository(new SecurityRoleRepository(dbContextFactory));
        RegisterRepository(new SystemCountryCodeRepository(dbContextFactory));
        RegisterRepository(new SystemLanguageCodeRepository(dbContextFactory));
    }
}
