using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Agumento.Core.Domain
{
    public class CandidateInterview : BaseEntity
    {
        [Required]
        public string CandidateName { get; set; }


        //[Display(Name = "OpenPosition")]
        //[ForeignKey("Id")]
        //public virtual Guid OpenPositionId { get; set; }

        [Display(Name = "CandidateProfile")]
        [ForeignKey("Id")]
        public virtual Guid CandidateId { get; set; }

        public string InterviewerName { get; set; }

        public DateTime ScheduledTime { get; set; }

        public bool IsSelected { get; set; }

        public string Feedback { get; set; }

        public string ModeOfInterview { get; set; }

        public string Level { get; set; }

    }
}
