using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        [Column(name: "Id")]
        public Guid Id { get; set; }

        [Column(name: "Login")]
        public Guid Login {  get; set; }

        [Column(name: "Role")]
        public Guid Role { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[]? TimeStamp { get; set; }
    }
}
