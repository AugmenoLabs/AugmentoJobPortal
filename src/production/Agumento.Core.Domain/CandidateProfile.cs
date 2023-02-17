using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Agumento.Core.Domain
{
    public class CandidateProfile : BaseEntity
    {
        [Required]
        public string CandidateName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public long ContactNumber { get; set; }

        public string? ResidentialAddress { get; set; }

        public string? PermanenetAddress { get; set; }

        
        public string Gender { get; set; }

        public string? MaritalStatus { get; set; }

        [Required]
        public int YearOfExperience { get; set; }

        [Required]
        public string? PrimarySkills { get; set; }

        public string? SecondarySkills { get; set; }

        public string? Qualification { get; set; }

        [Display(Name = "OpenPosition")]
        [ForeignKey("Id")]
        public virtual Guid OpenPositionId { get; set; }

        [Display(Name = "Vendor")]
        [ForeignKey("Id")]
        public virtual Guid VendorId { get; set; }

        public long CurrentCTC { get; set; }

        public long ExpectedCTC { get; set; }

        public string? NoticePeriod { get; set; }

        public bool HasOfferLetter { get; set; }

        public byte[] Resume { get; set; } 
        public string FileName { get; set; } 
        public string FileExt { get; set; } 

    }
}
