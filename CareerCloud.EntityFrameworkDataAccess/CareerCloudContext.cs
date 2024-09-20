using CareerCloud.Configurations;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

        private readonly ICareerCloudConfigResolver _configResolver;

        public CareerCloudContext()
            : this(CareerCloudConfigResolver.Instance)
        {

        }

        public CareerCloudContext(ICareerCloudConfigResolver configResolver)
        {
            _configResolver = configResolver;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_configResolver.GetConnectionString())
                .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            #region Company
            builder.Entity<CompanyProfilePoco>()
                .HasMany(e => e.CompanyJobs)
                .WithOne(e => e.CompanyProfile)
                .HasForeignKey(e => e.Company)
                .IsRequired();
            builder.Entity<CompanyProfilePoco>()
                .HasMany(e => e.CompanyLocations)
                .WithOne(e => e.CompanyProfile)
                .HasForeignKey(e => e.Company)
                .IsRequired();
            builder.Entity<CompanyProfilePoco>()
                .HasMany(e => e.CompanyDescriptions)
                .WithOne(e => e.CompanyProfile)
                .HasForeignKey(e => e.Company)
                .IsRequired();
            builder.Entity<CompanyDescriptionPoco>()
                .HasOne(e => e.SystemLanguageCode)
                .WithOne()
                .HasForeignKey<CompanyDescriptionPoco>(e => e.LanguageId)
                .IsRequired();
            builder.Entity<CompanyLocationPoco>()
                .HasOne(e => e.SystemCountryCode)
                .WithOne()
                .HasForeignKey<CompanyLocationPoco>(e => e.CountryCode)
                .IsRequired();
            #endregion

            #region Jobs
            builder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobEducations)
                .WithOne(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .IsRequired();
            builder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobDescriptions)
                .WithOne(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .IsRequired();
            builder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobEducations)
                .WithOne(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .IsRequired();
            builder.Entity<CompanyJobPoco>()
                .HasMany(e => e.CompanyJobSkills)
                .WithOne(e => e.CompanyJob)
                .HasForeignKey(e => e.Job)
                .IsRequired();
            #endregion

            #region Applicant
            builder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantEducations)
                .WithOne(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .IsRequired(false);
            builder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantJobApplications)
                .WithOne(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .IsRequired(false);
            builder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantResumes)
                .WithOne(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .IsRequired(false);
            builder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantSkills)
                .WithOne(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .IsRequired(false);
            builder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantWorkHistorys)
                .WithOne(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .IsRequired(false);
            builder.Entity<ApplicantJobApplicationPoco>()
                .HasOne(e => e.CompanyJob)
                .WithOne()
                .HasForeignKey<ApplicantJobApplicationPoco>(e => e.Job)
                .IsRequired();
            builder.Entity<ApplicantProfilePoco>()
                 .HasOne(e => e.SystemCountryCode)
                 .WithOne()
                 .HasForeignKey<ApplicantProfilePoco>(e => e.Country)
                 .IsRequired(false);
            builder.Entity<ApplicantWorkHistoryPoco>()
                .HasOne(e => e.SystemCountryCode)
                .WithOne()
                .HasForeignKey<ApplicantWorkHistoryPoco>(e => e.CountryCode)
                .IsRequired(false);
            #endregion

            #region Login
            builder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.SecurityLoginsLogs)
                .WithOne(e => e.SecurityLogin)
                .HasForeignKey(e => e.Login)
                .IsRequired();
            builder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.SecurityLoginsRoles)
                .WithOne(e => e.SecurityLogin)
                .HasForeignKey(e => e.Login)
                .IsRequired();
            builder.Entity<ApplicantProfilePoco>()
                .HasOne(e => e.SecurityLogin)
                .WithMany(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Login)
                .IsRequired();
            #endregion

            #region SecurityRole
            builder.Entity<SecurityLoginsRolePoco>()
                .HasOne(e => e.SecurityRole)
                .WithOne()
                .HasForeignKey<SecurityLoginsRolePoco>(e => e.Role)
                .IsRequired();
            builder.Entity<SecurityRolePoco>()
                .HasMany(e => e.SecurityLoginsRoles)
                .WithOne(e => e.SecurityRole)
                .HasForeignKey(e => e.Role)
                .IsRequired();
            #endregion

            #region Timestamp Fields
            builder.Entity<ApplicantEducationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<ApplicantJobApplicationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<ApplicantProfilePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<ApplicantSkillPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<ApplicantWorkHistoryPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<CompanyDescriptionPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<CompanyJobDescriptionPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<CompanyJobEducationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<CompanyJobPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<CompanyJobSkillPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<CompanyLocationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<CompanyProfilePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<SecurityLoginPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            builder.Entity<SecurityLoginsRolePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
            #endregion
        }
    }
}
