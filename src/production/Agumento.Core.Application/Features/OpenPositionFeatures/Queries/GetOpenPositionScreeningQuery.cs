using Agumento.Core.Application.Interfaces;
using MediatR;
using response = Agumento.Core.Application.ResponseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetOpenPositionScreeningQuery : IRequest<IEnumerable<response.CandidateProfile>>
    {
        public Guid Id { get; set; }
        public class GetOpenPositionScreeningQueryHandler : IRequestHandler<GetOpenPositionScreeningQuery, IEnumerable<response.CandidateProfile>>
        {
            private readonly IApplicationDbContext _context;
            public GetOpenPositionScreeningQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<response.CandidateProfile>> Handle(GetOpenPositionScreeningQuery request, CancellationToken cancellationToken)
            {
                var result = await GetOpenPositionsScreeningReport(request.Id);
                return result;
            }
            private async Task<IEnumerable<response.CandidateProfile>> GetOpenPositionsScreeningReport(Guid id)
            {
                var interviews = await (from ci in _context.CandidateInterviews select ci.CandidateId).ToListAsync();
                var candidates = await (from cp in _context.CandidateProfiles
                                        where !(interviews).Contains(cp.Id) && cp.OpenPositionId == id
                                        select new response.CandidateProfile
                                        {
                                            Id = cp.Id,
                                            CandidateName = cp.CandidateName,
                                            Email = cp.Email,
                                            OpenPositionId = cp.OpenPositionId,
                                            Resume = cp.Resume,
                                            FileExt= cp.FileExt,

                                        }).ToListAsync();
                return candidates;
            }
        }
    }
}
