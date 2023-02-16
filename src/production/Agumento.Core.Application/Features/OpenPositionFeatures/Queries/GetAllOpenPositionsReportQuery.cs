using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetAllOpenPositionsReportQuery : IRequest<IEnumerable<OpenPosition>>
    {
        public class GetAllOpenPositionsReportQueryHandler : IRequestHandler<GetAllOpenPositionsReportQuery, IEnumerable<OpenPosition>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOpenPositionsReportQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OpenPosition>> Handle(GetAllOpenPositionsReportQuery query, CancellationToken cancellationToken)
            {
                var openPositionsReport = await _context.OpenPositions.ToListAsync();
                //
                // _context.OpenPositions.Select(o => new { o.JobId, o.JobTitle,o.NoOfPositions,o.SkillSet,o.Budget,o.Location,o.YearOfExp,o.Qualification,o.});
                //var report= from o in _context.OpenPositions join c in _context.CandidateProfiles on o.Id equals c.Id select(new { o.JobId, o.JobTitle,o.A})
                if (openPositionsReport == null)
                {
                    return null;
                }
                return openPositionsReport.AsReadOnly();
            }

        }
    }
}
