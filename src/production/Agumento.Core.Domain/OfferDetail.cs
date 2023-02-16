using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agumento.Core.Domain
{
    public class OfferDetail : BaseEntity
    {

        [Display(Name = "Candidate")]
        [ForeignKey("Id")]
        public virtual Guid CandidateId { get; set; }

        [Display(Name = "OpenPosition")]
        [ForeignKey("Id")]
        public virtual Guid OpenPositionId { get; set; }

        public string? CompanyName { get; set; }

        public DateTime DateOfJoining { get; set; }

        public string? OfferedCTC { get; set; }

        public string EmploymentType { get; set; }
    }
}
