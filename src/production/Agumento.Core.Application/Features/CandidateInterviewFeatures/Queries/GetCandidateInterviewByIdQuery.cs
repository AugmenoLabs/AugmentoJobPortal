using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;

namespace Agumento.Core.Application.Features.CandidateInterviewFeatures.Queries
{
    public class GetCandidateInterviewByIdQuery : IRequest<CandidateInterview>
    {
        public Guid Id { get; set; }
        public class GetCandidateInterviewByIdQueryHandler : IRequestHandler<GetCandidateInterviewByIdQuery, CandidateInterview>
        {
            private readonly IApplicationDbContext _context;
            public GetCandidateInterviewByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<CandidateInterview> Handle(GetCandidateInterviewByIdQuery query, CancellationToken cancellationToken)
            {
                var project = _context.CandidateInterviews.Where(a => a.Id == query.Id).FirstOrDefault();

                if (project == null) return null;
                return project;
            }
        }
    }
}
