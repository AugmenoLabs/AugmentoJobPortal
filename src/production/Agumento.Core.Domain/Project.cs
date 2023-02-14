using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agumento.Core.Domain
{
    public class Project : BaseEntity
    {
        [Required]
        public string ProjectId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public string? ProjectDetails { get; set; }

        [Required]
        public string ProjectManager { get; set; }

        [Display(Name = "Account")]
        public virtual Guid AccountId { get; set; }

        [ForeignKey("Id")]
        public virtual Account Account { get; set; }
    }
}
