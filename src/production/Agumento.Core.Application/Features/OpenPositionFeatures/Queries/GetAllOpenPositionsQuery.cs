using Agumento.Core.Application.Interfaces;
using response = Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net.Sockets;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetAllOpenPositionsQuery : IRequest<IEnumerable<response.OpenPosition>>
    {
        public class GetAllOpenPositionsQueryHandler : IRequestHandler<GetAllOpenPositionsQuery, IEnumerable<response.OpenPosition>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetAllOpenPositionsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IEnumerable<response.OpenPosition>> Handle(GetAllOpenPositionsQuery query, CancellationToken cancellationToken)
            {
                var openPositionList = await _context.OpenPositions.ToListAsync();
                var openPositions = await GetOpenPositions();

                if (openPositions == null)
                {
                    return null;
                }
                return openPositions;
            }

            private async Task<IEnumerable<response.OpenPosition>> GetOpenPositions()
            {
                var positions = await (from op in _context.OpenPositions
                                       join acc in _context.Accounts on op.AccountId equals acc.Id
                                       join p in _context.Projects on op.ProjectId equals p.Id
                                       select new response.OpenPosition
                                       {
                                           Id= op.Id,
                                           JobId = op.JobId,
                                           JobTitle = op.JobTitle,
                                           AccountId = op.AccountId,
                                           AccountName = acc.AccountName,
                                           ProjectId = op.ProjectId,
                                           ProjectName = p.ProjectName,
                                           Budget = op.Budget,
                                           SkillSet= op.SkillSet,
                                           YearOfExp = op.YearOfExp,
                                           Qualification = op.Qualification,
                                           JobDescription = op.JobDescription,
                                           NoOfPositions = op.NoOfPositions,
                                           Location = op.Location
                                       }).ToListAsync();
                return positions;

            }

        }
    }
}
