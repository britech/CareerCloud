using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Company {  get; set; }

        [Column(name: "Profile_Created")]
        public DateTime ProfileCreated { get; set; }

        [Column(name: "Is_Inactive")]
        public bool IsInactive { get; set; }

        [Column(name: "Is_Company_Hidden")]
        public bool IsCompanyHidden {  get; set; }

        [Column(name: "Time_Stamp")]
        public byte[]? TimeStamp { get; set; }

        public virtual CompanyProfilePoco CompanyProfile { get; set; }
        public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
    }
}
