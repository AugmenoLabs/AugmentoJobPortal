using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                // _context.CandidateProfiles.Remove(candidateProfiles);
                candidateProfiles.IsDeleted = true;
                _context.CandidateProfiles.Update(candidateProfiles);

                await _context.SaveChanges();
                return candidateProfiles.Id;
            }
        }
    }
}
