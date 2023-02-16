using System.ComponentModel.DataAnnotations;

namespace Agumento.Core.Domain
{
    public class Vendor : BaseEntity
    {
        [Required]
        public string VendorId { get; set; }

        [Required]
        public string VendorName { get; set; }

        [Required]
        public string SPOCName { get; set; }

        [Required]
        public long SPOCContactNumber { get; set; }

        [Required]
        public string SPOCEmail { get; set; }

        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }
    }
}
