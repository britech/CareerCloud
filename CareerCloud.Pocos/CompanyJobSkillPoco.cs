using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

[Table(name: "Company_Job_Skills")]
public class CompanyJobSkillPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    public Guid Job { get; set; }

    [Column(name: "Skill")]
    public string Skill { get; set; }

    [Column(name: "Skill_Level")]
    public string SkillLevel { get; set; }

    [Column(name: "Importance")]
    public int Importance { get; set; }

    [JsonIgnore]
    [Column(name: "Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    [JsonIgnore]
    public virtual CompanyJobPoco CompanyJob { get; set; }
}
