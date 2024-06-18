using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        [Column(name: "Id")]
        public Guid Id { get; set; }

        [Column(name: "Login")]
        public Guid Login { get; set; }

        [Column(name: "Current_Salary")]
        public Decimal? CurrentSalary { get; set; }

        [Column(name: "Current_Rate")]
        public Decimal? CurrentRate { get; set; }

        [Column(name: "Currency")]
        public string? Currency { get; set; }

        [Column(name: "Country_Code")]
        public string? CountryCode { get; set; }

        [Column(name: "State_Province_Code")]
        public string? StateProvinceCode { get; set; }

        [Column(name: "Street_Address")]
        public string? StreetAddress { get; set; }

        [Column(name: "City_Town")]
        public string? CityTown {  get; set; }

        [Column(name: "Zip_Postal_Code")]
        public string? ZipPostalCode {  get; set; }

        [Column(name: "Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
