using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
