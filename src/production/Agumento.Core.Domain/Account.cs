using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Domain
{
    public class Account : BaseEntity
    {       
        public string? AccountId { get; set; }        
        public string? AccountName { get; set; }
        public string? AccountDetails { get; set; }
        public string? AccountManager { get; set; }
    }
}
