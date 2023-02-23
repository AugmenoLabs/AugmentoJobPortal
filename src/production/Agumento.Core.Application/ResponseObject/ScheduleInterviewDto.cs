
namespace Agumento.Core.Application.ResponseObject
{
    public class ScheduleInterview
    {
        public string Title { get; set; }
        public string? InterviewerName { get; set; }
        public string? InterviewerEmail { get; set; }
        public string? CCEMail { get; set; }
        public string? BCCEMail { get; set; }
        public string Round { get; set; }
        public DateTime ScheduledTimeFrom { get; set; }
        public DateTime ScheduledTimeTo { get; set; }
        public string ModeOfInterview { get; set; }
        public long? ContactNumber { get; set; }
        public string? MeetingLink { get; set; }
        public string Details { get; set; }
        public virtual Guid CandidateId { get; set; }
    }
}
