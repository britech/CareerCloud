using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

[SwaggerSchema(Required = ["id", "login"])]
[Table(name: "Applicant_Profiles")]
public class ApplicantProfilePoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    public Guid Login { get; set; }

    [Column(name: "Current_Salary")]
    public Decimal? CurrentSalary { get; set; }

    [Column(name: "Current_Rate")]
    public Decimal? CurrentRate { get; set; }

    [Column(name: "Currency")]
    public string? Currency { get; set; }

    [Column(name: "Country_Code")]
    public string? Country { get; set; }

    [Column(name: "State_Province_Code")]
    public string? Province { get; set; }

    [Column(name: "Street_Address")]
    public string? Street { get; set; }

    [Column(name: "City_Town")]
    public string? City { get; set; }

    [Column(name: "Zip_Postal_Code")]
    public string? PostalCode { get; set; }

    [JsonIgnore]
    [Column(name: "Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    [JsonIgnore]
    public virtual SecurityLoginPoco SecurityLogin { get; set; }

    [JsonIgnore]
    public virtual ICollection<ApplicantEducationPoco>? ApplicantEducations { get; set; }

    [JsonIgnore]
    public virtual ICollection<ApplicantJobApplicationPoco>? ApplicantJobApplications { get; set; }

    [JsonIgnore]
    public virtual ICollection<ApplicantResumePoco>? ApplicantResumes { get; set; }

    [JsonIgnore]
    public virtual ICollection<ApplicantSkillPoco>? ApplicantSkills { get; set; }

    [JsonIgnore]
    public virtual ICollection<ApplicantWorkHistoryPoco>? ApplicantWorkHistorys { get; set; }

    [JsonIgnore]
    public virtual SystemCountryCodePoco? SystemCountryCode { get; set; }
}
