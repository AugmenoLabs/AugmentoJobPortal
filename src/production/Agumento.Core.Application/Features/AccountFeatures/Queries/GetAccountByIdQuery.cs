using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;

namespace Agumento.Core.Application.Features.AccountFeatures.Queries
{
    public class GetAccountByIdQuery : IRequest<Account>
    {
        public Guid Id { get; set; }
        public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Account>
        {
            private readonly IApplicationDbContext _context;
            public GetAccountByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Account> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
            {
               // var account = _context.Accounts.Where(a => a.Id == query.Id).FirstOrDefault();
                var account = _context.Accounts.Where(a => a.Id == query.Id).Select(a => new Account()
                {
                    Id = a.Id,
                    AccountId = a.AccountId,
                    AccountName = a.AccountName,
                    AccountDetails = a.AccountDetails,
                    AccountManager = a.AccountManager,
                    Projects = a.Projects.ToList()
                }).FirstOrDefault();

                if (account == null) return null;
                return account;
            }
        }
    }
}
