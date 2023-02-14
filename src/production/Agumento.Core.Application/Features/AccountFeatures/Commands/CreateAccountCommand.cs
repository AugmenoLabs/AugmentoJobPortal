using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.AccountFeatures.Commands
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public string? AccountId { get; set; }
        public string? AccountName { get; set; }
        public string? AccountDetails { get; set; }
        public string? AccountManager { get; set; }

        public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateAccountCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    // Account account = _mapper.Map<Account>(request);
                    Account account = new();
                    account.AccountId = request.AccountId;
                    account.AccountName = request.AccountName;
                    account.AccountDetails = request.AccountDetails;
                    account.AccountManager = request.AccountManager;

                    _context.Accounts.Add(account);
                    await _context.SaveChanges();

                    return account.Id;
                }
                catch (Exception ex)
                {
                    return new Guid();
                }

                //Account account = new();
                //account.AccountId = request.AccountId;
                //account.AccountName = request.AccountName;
                //account.AccountDetails = request.AccountDetails;
                //account.AccountManager = request.AccountManager;

               
            }


        }
    }
}
