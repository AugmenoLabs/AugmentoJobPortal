using Agumento.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Features.JobOpeningFeatures.Commands
{
    public class DeleteJobOpeningByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteJobOpeningByIdCommandHandler : IRequestHandler<DeleteJobOpeningByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteJobOpeningByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteJobOpeningByIdCommand command, CancellationToken cancellationToken)
            {
                var openPosition = await _context.OpenPositions.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (openPosition == null) return default;
                _context.OpenPositions.Remove(openPosition);

                await _context.SaveChanges();
                return openPosition.Id;
            }
        }
    }
}
