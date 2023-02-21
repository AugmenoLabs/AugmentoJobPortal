using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Agumento.Core.Domain
{
    public class ScheduleInterview : BaseEntity
    {
        [Display(Name = "CandidateProfile")]
        [ForeignKey("Id")]
        public virtual Guid CandidateId { get; set; }

        [Required]
        public string Title { get; set; }
        public string? InterviewerName { get; set; }
        public string? InterviewerEmail { get; set; }
        public string? CCEMail { get; set; }
        public string? BCCEMail { get; set; }
        public string Round { get; set; }
        public DateTime ScheduledTimeFrom { get; set; }
        public DateTime ScheduledTimeTo { get; set; }

        [Required]
        public string ModeOfInterview { get; set; }
        public long? ContactNumber { get; set; }
        public string? MeetingLink { get; set; }
        public string Details { get; set; }

    }
}
