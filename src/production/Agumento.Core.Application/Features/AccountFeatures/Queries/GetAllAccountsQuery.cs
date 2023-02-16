using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                // var accountList = await _context.Accounts.ToListAsync();
                var accountList = _context.Accounts.Select(a => new Account()
                {
                    Id = a.Id,
                    AccountId = a.AccountId,
                    AccountName = a.AccountName,
                    AccountDetails = a.AccountDetails,
                    AccountManager = a.AccountManager,
                    Projects = a.Projects.ToList()
                }).ToList();

                if (accountList == null)
                {
                    return null;
                }
                return accountList.AsReadOnly();
            }

        }
    }
}
