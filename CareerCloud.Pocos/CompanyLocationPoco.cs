using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Company { get; set; }

        [Column(name: "Country_Code")]
        public string CountryCode { get; set; }

        [Column(name: "State_Province_Code")]
        public string? Province { get; set; }

        [Column(name: "Street_Address")]
        public string? Street { get; set; }

        [Column(name: "City_Town")]
        public string? City { get; set; }

        [Column(name: "Zip_Postal_Code")]
        public string? PostalCode { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
