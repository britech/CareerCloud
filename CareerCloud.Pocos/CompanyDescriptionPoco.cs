using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

[Table(name: "Company_Descriptions")]
public class CompanyDescriptionPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    public Guid Company { get; set; }

    [Column(name: "LanguageID")]
    public string LanguageId { get; set; }

    [Column(name: "Company_Name")]
    public string CompanyName { get; set; }

    [Column(name: "Company_Description")]
    public string CompanyDescription { get; set; }

    [JsonIgnore]
    [Column(name: "Time_Stamp")]
    public byte[] TimeStamp { get; set; }

    [JsonIgnore]
    public virtual CompanyProfilePoco CompanyProfile { get; set; }

    [JsonIgnore]
    public virtual SystemLanguageCodePoco SystemLanguageCode { get; set; }
}
