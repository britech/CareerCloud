using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFRepositoryRegistry : BaseRepositoryRegistry, IRepositoryFactory<Type>
    {
        private static readonly Lazy<EFRepositoryRegistry> _instance = new(() => new EFRepositoryRegistry());

        public static EFRepositoryRegistry Instance {  get { return _instance.Value; } }

        private EFRepositoryRegistry() : base() {
            base.RegisterRepository(typeof(ApplicantEducationPoco), new ApplicantEducationRepository());
            base.RegisterRepository(typeof(ApplicantJobApplicationPoco), new ApplicantJobApplicationRepository());
            base.RegisterRepository(typeof(ApplicantProfilePoco), new ApplicantProfileRepository());
            base.RegisterRepository(typeof(ApplicantResumePoco), new ApplicantResumeRepository());
            base.RegisterRepository(typeof(ApplicantSkillPoco), new ApplicantSkillRepository());
            base.RegisterRepository(typeof(ApplicantWorkHistoryPoco), new ApplicantWorkHistoryRepository());
            base.RegisterRepository(typeof(CompanyDescriptionPoco), new CompanyDescriptionRepository());
            base.RegisterRepository(typeof(CompanyJobDescriptionPoco), new CompanyJobDescriptionRepository());
            base.RegisterRepository(typeof(CompanyJobEducationPoco), new CompanyJobEducationRepository());
            base.RegisterRepository(typeof(CompanyJobPoco), new CompanyJobRepository());
            base.RegisterRepository(typeof(CompanyJobSkillPoco), new CompanyJobSkillRepository());
            base.RegisterRepository(typeof(CompanyLocationPoco), new CompanyLocationRepository());
            base.RegisterRepository(typeof(CompanyProfilePoco), new CompanyProfileRepository());
            base.RegisterRepository(typeof(SecurityLoginPoco), new SecurityLoginRepository());
            base.RegisterRepository(typeof(SecurityLoginsLogPoco), new SecurityLoginsLogRepository());
            base.RegisterRepository(typeof(SecurityLoginsRolePoco), new SecurityLoginsRoleRepository());
            base.RegisterRepository(typeof(SecurityRolePoco), new SecurityRoleRepository());
            base.RegisterRepository(typeof(SystemCountryCodePoco), new SystemCountryCodeRepository());
            base.RegisterRepository(typeof(SystemLanguageCodePoco), new SystemLanguageCodeRepository());
        }

        public IRepository GetRepository(Type id)
        {
            return base.GetRepository(id) ?? throw new ArgumentException($"No suitable repository for {id.Name}");
        }
    }
}
