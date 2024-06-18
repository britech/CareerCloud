using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column(name: "Registration_Date")]
        public DateTime RegistrationDate { get; set; }

        [Column(name: "Company_Website")]
        public string? CompanyWebsite { get; set; }

        [Column(name: "Contact_Phone")]
        public string ContactPhone { get; set; }

        [Column(name: "Contact_Name")]
        public string? ContactName { get; set; }

        [Column(name: "Company_Logo")]
        public Byte[]? CompanyLogo { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[]? TimeStamp { get; set; }
    }
}
