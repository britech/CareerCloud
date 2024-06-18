using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key]
        [Column(name: "Id")]
        public Guid Id { get; set; }

        [Column(name: "Applicant")]
        public Guid Applicant { get; set; }

        [Column(name: "Job")]
        public Guid Job { get; set; }

        [Column(name: "Application_Date")]
        public DateTime ApplicationDate { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
