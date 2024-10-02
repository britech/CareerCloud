using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

[Table(name: "Company_Job_Educations")]
public class CompanyJobEducationPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    public Guid Job { get; set; }

    [Column(name: "Major")]
    public string Major { get; set; }

    [Column(name: "Importance")]
    public Int16 Importance { get; set; }

    [JsonIgnore]
    [Column(name: "Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    [JsonIgnore]
    public virtual CompanyJobPoco CompanyJob { get; set; }
}
