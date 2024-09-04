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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(CareerCloudConfigurationLoader.Instance.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
            builder.Entity<SystemLanguageCodePoco>()
                .HasOne<CompanyDescriptionPoco>()
                .WithOne()
                .HasForeignKey<CompanyDescriptionPoco>(e => e.LanguageId)
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
                .HasMany(e => e.ApplicantWorkHistory)
                .WithOne(e => e.ApplicantProfile)
                .HasForeignKey(e => e.Applicant)
                .IsRequired(false);
            builder.Entity<ApplicantJobApplicationPoco>()
                .HasOne(e => e.CompanyJob)
                .WithOne()
                .HasForeignKey<ApplicantJobApplicationPoco>(e => e.Job)
                .IsRequired();
            builder.Entity<SystemCountryCodePoco>()
                .HasOne<ApplicantProfilePoco>()
                .WithOne()
                .HasForeignKey<ApplicantProfilePoco>(e => e.Country)
                .IsRequired(false);
            builder.Entity<ApplicantProfilePoco>()
                .HasOne(e => e.SecurityLogin)
                .WithOne()
                .HasForeignKey<ApplicantProfilePoco>(e => e.Login)
                .IsRequired();
            builder.Entity<SystemCountryCodePoco>()
                .HasOne<ApplicantWorkHistoryPoco>()
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
            #endregion

            #region SecurityRole
            builder.Entity<SecurityLoginsRolePoco>()
                .HasOne(e => e.SecurityRole)
                .WithOne()
                .HasForeignKey<SecurityLoginsRolePoco>(e => e.Role)
                .IsRequired();
            #endregion
        }
    }
}
