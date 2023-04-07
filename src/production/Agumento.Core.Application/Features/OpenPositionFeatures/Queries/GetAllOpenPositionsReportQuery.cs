using Agumento.Core.Application.Interfaces;
using response = Agumento.Core.Application.ResponseObject;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetAllOpenPositionsReportQuery : IRequest<IEnumerable<response.OpenPositionReport>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public class GetAllOpenPositionsReportQueryHandler : IRequestHandler<GetAllOpenPositionsReportQuery, IEnumerable<response.OpenPositionReport>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOpenPositionsReportQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<response.OpenPositionReport>> Handle(GetAllOpenPositionsReportQuery query, CancellationToken cancellationToken)
            {
                var openPositionReports = await GetOpenPositionsReport(query);
                return openPositionReports;
            }
            private async Task<IEnumerable<response.OpenPositionReport>> GetOpenPositionsReport(GetAllOpenPositionsReportQuery query)
            {
                var result = await (from op in _context.OpenPositions
                                    join acc in _context.Accounts on op.AccountId equals acc.Id
                                    join pr in _context.Projects on op.ProjectId equals pr.Id
                                    join cp in _context.CandidateProfiles on op.Id equals cp.OpenPositionId into cpGroup
                                    from cp in cpGroup.DefaultIfEmpty()
                                    group op by new { op.Id, acc.AccountName, pr.ProjectName } into grouped
                                    orderby grouped.First().CreatedOn descending
                                    select new response.OpenPositionReport
                                    {
                                        Id = grouped.Key.Id,
                                        JobId = grouped.First().JobId,
                                        JobTitle = grouped.First().JobTitle,
                                        AccountId = grouped.First().AccountId,
                                        AccountName = grouped.Key.AccountName,
                                        ProjectId = grouped.First().ProjectId,
                                        ProjectName = grouped.Key.ProjectName,
                                        Budget = grouped.First().Budget,
                                        SkillSet = grouped.First().SkillSet,
                                        YearOfExp = grouped.First().YearOfExp,
                                        Qualification = grouped.First().Qualification,
                                        JobDescription = grouped.First().JobDescription,
                                        NoOfPositions = grouped.First().NoOfPositions,
                                        Location = grouped.First().Location,
                                        TotalApplied = grouped.Select(x => x.CandidateProfiles.Count).FirstOrDefault(),
                                        PostedOn = grouped.First().CreatedOn
                                    }).Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToListAsync();
                return result;
            }
        }
    }
}
