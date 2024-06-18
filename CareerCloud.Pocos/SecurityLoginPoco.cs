using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {
        [Key]
        [Column(name: "Id")]
        public Guid Id { get; set; }

        [Column(name: "Login")]
        public string Login { get; set; }

        [Column(name: "Password")]
        public string Password { get; set; }

        [Column(name: "Created_Date")]
        public DateTime Created { get; set; }

        [Column(name: "Password_Update_Date")]
        public DateTime? PasswordUpdate { get; set; }

        [Column(name: "Agreement_Accepted_Date")]
        public DateTime? AgreementAccepted { get; set; }

        [Column(name: "Is_Locked")]
        public bool IsLocked { get; set; }

        [Column(name: "Is_Inactive")]
        public bool IsInactive { get; set; }

        [Column(name: "Email_Address")]
        public string EmailAddress {  get; set; }

        [Column(name: "Phone_Number")]
        public string? PhoneNumber { get; set; }

        [Column(name: "Full_Name")]
        public string? FullName { get; set; }

        [Column(name: "Force_Change_Password")]
        public bool ForceChangePassword {  get; set; }

        [Column(name: "Prefferred_Language")]
        public string PrefferredLanguage { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
