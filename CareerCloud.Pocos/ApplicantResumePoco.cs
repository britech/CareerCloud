using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

[SwaggerSchema(Required = ["id", "applicant", "resume"])]
[Table(name: "Applicant_Resumes")]
public class ApplicantResumePoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    public Guid Applicant { get; set; }

    [Column(name: "Resume")]
    public string Resume { get; set; }

    [SwaggerSchema(Format = "date")]
    [Column(name: "Last_Updated")]
    public DateTime? LastUpdated { get; set; }

    [JsonIgnore]
    public virtual ApplicantProfilePoco? ApplicantProfile { get; set; }
}
