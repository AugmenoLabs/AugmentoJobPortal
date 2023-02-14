using Agumento.Core.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Features.AccountFeatures.Commands
{
    public class UpdateAccountCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? AccountId { get; set; }
        public string? AccountName { get; set; }
        public string? AccountDetails { get; set; }
        public string? AccountManager { get; set; }

        public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public UpdateAccountCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
            {
                var account = _context.Accounts.Where(a => a.Id == command.Id).FirstOrDefault();

                if (account == null)
                {
                    return default;
                }
                else
                {
                    account.Id = command.Id;
                    account.AccountId = command.AccountId;
                    account.AccountName = command.AccountName;
                    account.AccountDetails = command.AccountDetails;
                    account.AccountManager = command.AccountManager;

                    _context.Accounts.Add(account);
                    await _context.SaveChanges();

                    return account.Id;
                }
            }
        }
    }
}
