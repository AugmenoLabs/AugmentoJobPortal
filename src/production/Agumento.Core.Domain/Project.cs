using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Domain
{
    public class Project : BaseEntity
    {  
        [Required]
        public string? ProjectName { get; set; }

        public string? ProjectDetails { get; set; }

        [Required]
        public string? ProjectManager { get; set; }

        [Display(Name = "Account")]
        public virtual Guid AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
