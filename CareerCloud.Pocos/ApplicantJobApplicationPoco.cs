using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

[SwaggerSchema(Required = ["id", "applicant", "job", "applicationDate"])]
[Table(name: "Applicant_Job_Applications")]
public class ApplicantJobApplicationPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    public Guid Applicant { get; set; }

    [Column(name: "Job")]
    public Guid Job { get; set; }

    [SwaggerSchema(Format = "date-time")]
    [Column(name: "Application_Date")]
    public DateTime ApplicationDate { get; set; }

    [JsonIgnore]
    [Column(name: "Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    [JsonIgnore]
    public virtual ApplicantProfilePoco? ApplicantProfile { get; set; }

    [JsonIgnore]
    public virtual CompanyJobPoco? CompanyJob { get; set; }
}
