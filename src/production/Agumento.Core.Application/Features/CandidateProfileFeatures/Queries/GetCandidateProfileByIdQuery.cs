using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;

namespace Agumento.Core.Application.Features.CandidateProfileFeatures.Queries
{
    public class GetCandidateProfileByIdQuery : IRequest<CandidateProfile>
    {
        public Guid Id { get; set; }
        public class GetCandidateProfileByIdQueryHandler : IRequestHandler<GetCandidateProfileByIdQuery, CandidateProfile>
        {
            private readonly IApplicationDbContext _context;
            public GetCandidateProfileByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<CandidateProfile> Handle(GetCandidateProfileByIdQuery query, CancellationToken cancellationToken)
            {
                var candidateProfile = _context.CandidateProfiles.Where(a => a.Id == query.Id).FirstOrDefault();

                if (candidateProfile == null) return null;

                return candidateProfile;
            }
        }
    }
}

