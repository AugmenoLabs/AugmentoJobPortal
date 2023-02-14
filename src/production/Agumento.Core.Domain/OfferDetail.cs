using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Domain
{
    public class OfferDetail
    {
        [Key]
        public Guid OfferId { get; set; }

        [Display(Name = "CandidateProfile")]
        public virtual Guid CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual CandidateProfile CandidateProfile { get; set; }

        [Display(Name = "OpenPosition")]
        public virtual Guid Id { get; set; }

        [ForeignKey("Id")]
        public virtual OpenPosition OpenPosition { get; set; }

        [Required]
        public string? CompanyName { get; set; }

        public DateTime DateOfJoining { get; set; }

        public string? OfferedCTC { get; set; }
    }
}
