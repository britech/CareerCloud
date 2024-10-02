using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

[Table(name: "Security_Logins_Roles")]
public class SecurityLoginsRolePoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    public Guid Login {  get; set; }

    public Guid Role { get; set; }

    [JsonIgnore]
    [Column(name: "Time_Stamp")]
    public byte[]? TimeStamp { get; set; }

    [JsonIgnore]
    public virtual SecurityLoginPoco SecurityLogin { get; set; }

    [JsonIgnore]
    public virtual SecurityRolePoco SecurityRole { get; set; }
}
