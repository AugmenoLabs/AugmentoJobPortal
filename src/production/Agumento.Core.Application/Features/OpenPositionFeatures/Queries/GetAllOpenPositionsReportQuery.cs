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
                var openPositionReports = await GetOpenPositionsReport();
                return openPositionReports;
            }
            private async Task<IEnumerable<response.OpenPositionReport>> GetOpenPositionsReport()
            {
                var position = await (from op in _context.OpenPositions
                                      join acc in _context.Accounts on op.AccountId equals acc.Id
                                      join p in _context.Projects on op.ProjectId equals p.Id
                                      join c in _context.CandidateProfiles on op.Id equals c.OpenPositionId
                                      select new response.OpenPositionReport
                                      {
                                          JobId = op.JobId,
                                          JobTitle = op.JobTitle,
                                          AccountId = op.AccountId,
                                          AccountName = acc.AccountName,
                                          ProjectId = op.ProjectId,
                                          ProjectName = p.ProjectName,
                                          Budget = op.Budget,
                                          YearOfExp = op.YearOfExp,
                                          Qualification = op.Qualification,
                                          JobDescription = op.JobDescription,
                                          NoOfPositions = op.NoOfPositions,
                                          Location = op.Location,
                                          //TotalApplied= 
                                          //Screenings
                                          L1s = c.CandidateInterviews.Where(i => i.Level.Equals("L1")).Count(),
                                          L2s = c.CandidateInterviews.Where(i => i.Level.Equals("L2")).Count(),
                                          Managerials = c.CandidateInterviews.Where(i => i.Level.Equals("Managerial")).Count(),
                                          HR = c.CandidateInterviews.Where(i => i.Level.Equals("HR")).Count(),
                                          Offers = c.CandidateInterviews.Where(i => i.Level.Equals("Offers")).Count(),
                                          Onboarded = c.CandidateInterviews.Where(i => i.Level.Equals("Onboarded")).Count(),

                                      }).ToListAsync();
                return position;

            }

        }
    }
}
