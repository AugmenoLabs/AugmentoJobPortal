using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Commands
{
    public class DeleteOpenPositionByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteOpenPositionByIdCommandHandler : IRequestHandler<DeleteOpenPositionByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteOpenPositionByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteOpenPositionByIdCommand command, CancellationToken cancellationToken)
            {
                var openPosition = await _context.OpenPositions.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (openPosition == null) return default;
                // _context.OpenPositions.Remove(openPosition);
                openPosition.IsDeleted = true;
                _context.OpenPositions.Update(openPosition);

                await _context.SaveChanges();
                return openPosition.Id;
            }
        }
    }
}
