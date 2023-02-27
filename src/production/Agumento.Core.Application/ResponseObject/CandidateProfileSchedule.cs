using Agumento.Core.Domain;

namespace Agumento.Core.Application.ResponseObject
{
    public class CandidateProfileSchedule
    {
        public string CandidateName { get; set; }

        public string Email { get; set; }

        public long ContactNumber { get; set; }
        public string? AccountName { get; set; }
        public string? ProjectName { get; set; }

        public string? ResidentialAddress { get; set; }

        public string? PermanenetAddress { get; set; }

        public string Gender { get; set; }

        public string? MaritalStatus { get; set; }

        public int YearOfExperience { get; set; }

        public string? PrimarySkills { get; set; }

        public string? SecondarySkills { get; set; }

        public string? Qualification { get; set; }

        public Guid OpenPositionId { get; set; }

        public Guid VendorId { get; set; }
        public string VendorName { get; set; }

        public string? NoticePeriod { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string? InterviewerName { get; set; }

        public bool HasOfferLetter { get; set; }

        public byte[] Resume { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }

        public IEnumerable<CandidateInterview> CandidateFeedbacks { get; set; }
    }
}
