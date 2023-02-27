using Agumento.Core.Application.Interfaces;
using response = Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetAllOpenPositionsReportQuery : IRequest<IEnumerable<response.OpenPositionReport>>
    {
        public class GetAllOpenPositionsReportQueryHandler : IRequestHandler<GetAllOpenPositionsReportQuery, IEnumerable<response.OpenPositionReport>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOpenPositionsReportQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<response.OpenPositionReport>> Handle(GetAllOpenPositionsReportQuery query, CancellationToken cancellationToken)
            {
                var openPositionsReport = await _context.OpenPositions.ToListAsync();
                //
                // _context.OpenPositions.Select(o => new { o.JobId, o.JobTitle,o.NoOfPositions,o.SkillSet,o.Budget,o.Location,o.YearOfExp,o.Qualification,o.});
                //var report= from o in _context.OpenPositions join c in _context.CandidateProfiles on o.Id equals c.Id select(new { o.JobId, o.JobTitle,o.A})
                //if (openPositionsReport == null)
                //{
                //    return null;
                //}
                //return openPositionsReport.AsReadOnly();
                return null;
            }
            //private async Task<IEnumerable<response.OpenPositionReport>> GetOpenPositionsReport()
            //{
            //    var position = await (from op in _context.OpenPositions
            //                          join acc in _context.Accounts on op.AccountId equals acc.Id
            //                          join p in _context.Projects on op.ProjectId equals p.Id
            //                          join c in _context.CandidateProfiles op.openPositionId equals c.Id
            //                          select new response.OpenPositionReport
            //                          {
            //                              JobId = op.JobId,
            //                              JobTitle = op.JobTitle,
            //                              AccountId = op.AccountId,
            //                              AccountName = acc.AccountName,
            //                              ProjectId = op.ProjectId,
            //                              ProjectName = p.ProjectName,
            //                              Budget = op.Budget,
            //                              YearOfExp = op.YearOfExp,
            //                              Qualification = op.Qualification,
            //                              JobDescription = op.JobDescription,
            //                              NoOfPositions = op.NoOfPositions,
            //                              Location = op.Location,

            //                          }).FirstOrDefaultAsync();
            //    return position;

            //}

        }
    }
}
