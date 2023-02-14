using System.ComponentModel.DataAnnotations;

namespace Agumento.Core.Domain
{
    public class Account : BaseEntity
    {
        [Required]
        public string AccountId { get; set; }

        [Required]
        public string AccountName { get; set; }
        public string? AccountDetails { get; set; }

        [Required]
        public string AccountManager { get; set; }
    }
}
