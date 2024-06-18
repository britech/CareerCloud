using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Company_Jobs_Descriptions")]
    public class CompanyJobDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Job { get; set; }

        [Column(name: "Job_Name")]
        public string? JobName { get; set; }

        [Column(name: "Job_Descriptions")]
        public string? JobDescriptions { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[]? TimeStamp { get; set; }
    }
}
