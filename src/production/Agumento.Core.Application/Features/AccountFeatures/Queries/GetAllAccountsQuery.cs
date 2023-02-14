using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Features.AccountFeatures.Queries
{
    public class GetAllAccountsQuery : IRequest<IEnumerable<Account>>
    {
        public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Account>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllAccountsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery query, CancellationToken cancellationToken)
            {
                var accountList = await _context.Accounts.ToListAsync();

                if (accountList == null)
                {
                    return null;
                }
                return accountList.AsReadOnly();
            }

        }
    }
}
