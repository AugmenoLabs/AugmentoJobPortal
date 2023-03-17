using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agumento.Core.Domain
{
    public class OpenPosition : BaseEntity
    {
        [Required]
        public string JobId { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Display(Name = "Account")]
        [ForeignKey("Id")]
        public virtual Guid AccountId { get; set; }

        [Display(Name = "Project")]
        [ForeignKey("Id")]
        public virtual Guid ProjectId { get; set; }

        [Display(Name = "CandidateProfile")]
        [ForeignKey("Id")]
        public virtual Guid CandidateProfileId { get; set; }

        public string Budget { get; set; }

        [Required]
        public string? SkillSet { get; set; }

        [Required]
        public decimal YearOfExp { get; set; }

        public string? Qualification { get; set; }

        [Required]
        public string? JobDescription { get; set; }


        public int NoOfPositions { get; set; }

        public string? Location { get; set; }

        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }
    }
}
