using Agumento.Core.Application.Interfaces;
using response = Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetAllOpenPositionsByIdQuery : IRequest<response.OpenPosition>
    {
        public Guid Id { get; set; }
        public class GetAllOpenPositionsByIdQueryHandler : IRequestHandler<GetAllOpenPositionsByIdQuery, response.OpenPosition>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOpenPositionsByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<response.OpenPosition> Handle(GetAllOpenPositionsByIdQuery query, CancellationToken cancellationToken)
            {
                // var openPosition = _context.OpenPositions.Where(a => a.Id == query.Id).FirstOrDefault();
                var openPosition = await GetOpenPosition(query.Id);

                if (openPosition == null) return null;
                return openPosition;
            }
            private async Task<response.OpenPosition> GetOpenPosition(Guid id)
            {
                var position = await (from op in _context.OpenPositions
                                      join acc in _context.Accounts on op.AccountId equals acc.Id
                                      join p in _context.Projects on op.ProjectId equals p.Id
                                      where op.Id == id
                                      select new response.OpenPosition
                                      {
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
                                          Location = op.Location
                                      }).FirstOrDefaultAsync();
                return position;

            }
        }
    }
}
