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
                var openPositionReports = await GetOpenPositionsReport();
                return openPositionReports;
            }
            private async Task<IEnumerable<response.OpenPositionReport>> GetOpenPositionsReport()
            {

                var position = await (from op in _context.OpenPositions
                                      join acc in _context.Accounts on op.AccountId equals acc.Id
                                      join p in _context.Projects on op.ProjectId equals p.Id
                                      join c in _context.CandidateProfiles
                                        on op.Id equals c.OpenPositionId into candidates
                                      from candidate in candidates.DefaultIfEmpty()
                                      orderby op.CreatedOn descending
                                      select new response.OpenPositionReport
                                      {
                                          Id = op.Id,
                                          JobId = op.JobId,
                                          JobTitle = op.JobTitle,
                                          AccountId = op.AccountId,
                                          AccountName = acc.AccountName,
                                          ProjectId = op.ProjectId,
                                          ProjectName = p.ProjectName,
                                          Budget = op.Budget,
                                          SkillSet = op.SkillSet,
                                          YearOfExp = op.YearOfExp,
                                          Qualification = op.Qualification,
                                          JobDescription = op.JobDescription,
                                          NoOfPositions = op.NoOfPositions,
                                          Location = op.Location,
                                          PostedOn = op.CreatedOn,
                                          L1s = candidate.CandidateInterviews
                                            .Count(i => i.Level.Equals("L1")),
                                          L2s = candidate.CandidateInterviews
                                            .Count(i => i.Level.Equals("L2")),
                                          Managerials = candidate.CandidateInterviews
                                            .Count(i => i.Level.Equals("Managerial")),
                                          HR = candidate.CandidateInterviews
                                            .Count(i => i.Level.Equals("HR")),
                                          Offers = candidate.CandidateInterviews
                                            .Count(i => i.Level.Equals("Offers")),
                                          Onboarded = candidate.CandidateInterviews
                                            .Count(i => i.Level.Equals("Onboarded"))
                                      }).ToListAsync();

                return position;

            }

        }
    }
}
