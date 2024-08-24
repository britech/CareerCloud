using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Applicant_Work_History")]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Applicant { get; set; }

        [Column(name: "Company_Name")]
        public string CompanyName { get; set; }

        [Column(name: "Country_Code")]
        public string CountryCode { get; set; }

        [Column(name: "Location")]
        public string Location { get; set; }

        [Column(name: "Job_Title")]
        public string JobTitle { get; set; }

        [Column(name: "Job_Description")]
        public string JobDescription { get; set; }

        [Column(name: "Start_Month")]
        public Int16 StartMonth { get; set; }

        [Column(name: "Start_Year")]
        public int StartYear { get; set; }

        [Column(name: "End_Month")]
        public Int16 EndMonth { get; set; }

        [Column(name: "End_Year")]
        public int EndYear { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco? ApplicantProfile { get; set; }
    }
}
