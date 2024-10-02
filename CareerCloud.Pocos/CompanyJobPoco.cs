using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

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

    [JsonIgnore]
    [Column(name: "Time_Stamp")]
    public byte[]? TimeStamp { get; set; }

    [JsonIgnore]
    public virtual CompanyProfilePoco CompanyProfile { get; set; }

    [JsonIgnore]
    public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }

    [JsonIgnore]
    public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }

    [JsonIgnore]
    public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
}
