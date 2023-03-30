using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.CandidateProfileFeatures.Queries
{
    public class GetAllCandidateProfileByJobIdQuery : IRequest<IEnumerable<CandidateProfile>>
    {
        public Guid OpenPositionId { get; set; }
        public class GetAllCandidateProfileByJobIdQueryHandler : IRequestHandler<GetAllCandidateProfileByJobIdQuery, IEnumerable<CandidateProfile>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCandidateProfileByJobIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CandidateProfile>> Handle(GetAllCandidateProfileByJobIdQuery query, CancellationToken cancellationToken)
            {
                var candidateProfileList = await _context.CandidateProfiles.Where(a => a.OpenPositionId == query.OpenPositionId).ToListAsync();

                if (candidateProfileList == null)
                {
                    return null;
                }
                return candidateProfileList.AsReadOnly();
            }

        }
    }
}

