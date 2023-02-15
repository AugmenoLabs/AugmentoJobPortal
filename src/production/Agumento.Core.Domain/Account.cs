using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agumento.Core.Domain
{
    public class Account : BaseEntity
    {
        public Account()
        {
            this.Projects = new HashSet<Project>();
        }

        //[Required]
        public string AccountId { get; set; }

        //[Required]
        public string AccountName { get; set; }
        public string? AccountDetails { get; set; }

        //[Required]
        public string AccountManager { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
