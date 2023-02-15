using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.AccountFeatures.Commands
{
    public class DeleteAccountByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteAccountByIdCommandHandler : IRequestHandler<DeleteAccountByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteAccountByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteAccountByIdCommand command, CancellationToken cancellationToken)
            {
                var account = await _context.Accounts.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (account == null) return default;
                //_context.Accounts.Remove(account);
                account.IsDeleted = true;
                _context.Accounts.Update(account);

                await _context.SaveChanges();
                return account.Id;
            }
        }
    }
}
