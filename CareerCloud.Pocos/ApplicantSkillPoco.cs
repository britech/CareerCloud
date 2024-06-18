using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table(name: "Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Applicant { get; set; }

        [Column(name: "Skill")]
        public string Skill { get; set; }

        [Column(name: "Skill_Level")]
        public string SkillLevel { get; set; }

        [Column(name: "Start_Month")]
        public Byte StartMonth { get; set; }

        [Column(name: "Start_Year")]
        public int StartYear { get; set; }

        [Column(name: "End_Month")]
        public Byte EndMonth { get; set; }

        [Column(name: "End_Year")]
        public Byte EndYear { get; set; }

        [Column(name: "Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
