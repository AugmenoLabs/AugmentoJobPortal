using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetAllOpenPositionsQuery : IRequest<IEnumerable<OpenPosition>>
    {
        public class GetAllOpenPositionsQueryHandler : IRequestHandler<GetAllOpenPositionsQuery, IEnumerable<OpenPosition>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOpenPositionsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OpenPosition>> Handle(GetAllOpenPositionsQuery query, CancellationToken cancellationToken)
            {
                var openPositions = await _context.OpenPositions.ToListAsync();

                if (openPositions == null)
                {
                    return null;
                }
                return openPositions.AsReadOnly();
            }

        }
    }
}
