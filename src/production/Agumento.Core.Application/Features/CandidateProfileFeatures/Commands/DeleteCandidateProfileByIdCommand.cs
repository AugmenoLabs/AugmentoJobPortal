using Agumento.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Features.CandidateProfileFeatures.Commands
{
    public class DeleteCandidateProfileByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteCandidateProfileByIdCommandHandler : IRequestHandler<DeleteCandidateProfileByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCandidateProfileByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteCandidateProfileByIdCommand command, CancellationToken cancellationToken)
            {
                var candidateProfiles = await _context.CandidateProfiles.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (candidateProfiles == null) return default;
                _context.CandidateProfiles.Remove(candidateProfiles);

                await _context.SaveChanges();
                return candidateProfiles.Id;
            }
        }
    }
}
