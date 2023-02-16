using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Agumento.Core.Domain
{
    public class CandidateInterview : BaseEntity
    {
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
