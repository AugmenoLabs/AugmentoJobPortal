using System.ComponentModel.DataAnnotations;

namespace Agumento.Core.Domain
{
    public class Vendor : BaseEntity
    {
        //[Key]
        //public Guid VendorId { get; set; }

        public string? VendorName { get; set; }

        [Required]
        public string? SPOCName { get; set; }

        [Required]
        public long SPOCContactNumber { get; set; }

        [Required]
        public string? SPOCEmail { get; set; }
    }
}
