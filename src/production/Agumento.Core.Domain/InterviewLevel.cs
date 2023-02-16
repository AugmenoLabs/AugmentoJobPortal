using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agumento.Core.Domain
{
    public class InterviewLevel: BaseEntity
    {

        [Required]
        public string Screening { get; set; }

        public Levels L1 { get; set; }

        public Levels L2 { get; set; }

        public Levels SystemTest { get; set; }

        public Levels HR { get; set; }

        public Offers Offer { get; set; }

        public bool Onboarded { get; set; }

        [Display(Name = "Candidate")]
        [ForeignKey("Id")]
        public virtual Guid OpenPositionId { get; set; }

    }

    public enum Levels
    {
        Scheduled, 
        Pending, 
        Cleared, 
        Skipped, 
        ReScheduled, 
        Refused
    }

    public enum Offers
    {
        RolledOut, 
        Accepted, 
        Rejected
    }
}
