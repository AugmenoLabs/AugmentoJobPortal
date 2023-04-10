using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.ResponseObject
{
    public class PaginationResponse<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
        public PaginationResponse() 
        { 
            Items = new List<T>();
        }
    }
}
