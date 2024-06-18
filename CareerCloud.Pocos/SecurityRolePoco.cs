using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Security_Roles")]
    public class SecurityRolePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column(name: "Role")]
        public string Role { get; set; }

        [Column(name: "Is_Inactive")]
        public bool IsInactive { get; set; }
    }
}
