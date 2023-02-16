using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.CandidateInterviewFeatures.Queries
{
    public class GetAllCandidateInterviewsQuery : IRequest<IEnumerable<CandidateInterview>>
    {
        public class GetAllCandidateInterviewsQueryHandler : IRequestHandler<GetAllCandidateInterviewsQuery, IEnumerable<CandidateInterview>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCandidateInterviewsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CandidateInterview>> Handle(GetAllCandidateInterviewsQuery query, CancellationToken cancellationToken)
            {
                var candidateInterviews = await _context.CandidateInterviews.ToListAsync();

                if (candidateInterviews == null)
                {
                    return null;
                }
                return candidateInterviews.AsReadOnly();
            }
        }
    }
}
