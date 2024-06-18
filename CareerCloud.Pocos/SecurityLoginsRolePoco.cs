using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Login {  get; set; }

        public Guid Role { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[]? TimeStamp { get; set; }
    }
}
