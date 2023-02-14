using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agumento.Core.Domain
{
    public class OpenPosition : BaseEntity
    {
        //[Key]
        //public Guid Id { get; set; }

        [Required]
        public long JobId { get; set; }

        public string? JobTitle { get; set; }

        [Display(Name = "Account")]
        public virtual Guid AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Display(Name = "Project")]
        public virtual Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [Required]
        public string? SkillSet { get; set; }

        [Required]
        public decimal YearOfExp { get; set; }

        public string? Qualification { get; set; }

        [Required]
        public string? JobDescription { get; set; }


        public int NoOfPositions { get; set; }

        //County-State-City
        public string? Location { get; set; }
    }
}
