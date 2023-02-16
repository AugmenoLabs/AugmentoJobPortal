using Agumento.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.CandidateInterviewFeatures.Commands
{
    public class DeleteCandidateInterviewByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteCandidateInterviewByIdCommandHandler : IRequestHandler<DeleteCandidateInterviewByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCandidateInterviewByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteCandidateInterviewByIdCommand command, CancellationToken cancellationToken)
            {
                var candidateInterview = await _context.CandidateInterviews.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (candidateInterview == null) return default;
                // _context.Projects.Remove(project);
                candidateInterview.IsDeleted = true;
                _context.CandidateInterviews.Update(candidateInterview);

                await _context.SaveChanges();
                return candidateInterview.Id;
            }
        }
    }
}
