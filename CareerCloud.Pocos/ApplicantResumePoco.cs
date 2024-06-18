using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Applicant_Resumes")]
    public class ApplicantResumePoco : IPoco
    {
        [Key]
        [Column(name: "Id")]
        public Guid Id { get; set; }

        [Column(name: "Applicant")]
        public Guid Applicant { get; set; }

        [Column(name: "Resume")]
        public string Resume { get; set; }

        [Column(name: "Last_Updated")]
        public DateTime? LastUpdated { get; set; }
    }
}
