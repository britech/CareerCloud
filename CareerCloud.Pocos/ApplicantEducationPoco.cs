using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Applicant_Educations")]
    public class ApplicantEducationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Applicant { get; set; }

        [Column(name: "Major")]
        public string Major {  get; set; }

        [Column(name: "Certificate_Diploma")]
        public string? CertificateDiploma { get; set; }

        [Column(name: "Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column(name: "Completion_Date")]
        public DateTime? CompletionDate { get; set; }

        [Column(name: "Completion_Percent")]
        public Byte? CompletionPercent { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
