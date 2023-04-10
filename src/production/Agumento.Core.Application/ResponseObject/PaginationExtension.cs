using Agumento.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.ResponseObject
{
    public static class PaginationExtension
    {
        public static async Task<PaginationResponse<T>> PaginateAsync<T>(
           this IQueryable<T> query,
           int pageSize,
           int pageNumber,
           CancellationToken cancellationToken = default)
        {
            var pagedList = new PaginationResponse<T>
            {
                TotalItems = await query.CountAsync(cancellationToken),
                Items = await query.Skip((++pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken)
            };
            return pagedList;
        }
    }
}
