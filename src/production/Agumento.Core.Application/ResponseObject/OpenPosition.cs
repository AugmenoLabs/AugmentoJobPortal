
namespace Agumento.Core.Application.ResponseObject
{
    public class OpenPosition
    {
        public string JobId { get; set; }
        public string JobTitle { get; set; }

        public Guid AccountId { get; set; }
        public string AccountName { get; set; }

        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }

        public string Budget { get; set; }

        public string? SkillSet { get; set; }

        public decimal YearOfExp { get; set; }
        public string? Qualification { get; set; }
        public string? JobDescription { get; set; }
        public int NoOfPositions { get; set; }
        public string? Location { get; set; }
    }
}
