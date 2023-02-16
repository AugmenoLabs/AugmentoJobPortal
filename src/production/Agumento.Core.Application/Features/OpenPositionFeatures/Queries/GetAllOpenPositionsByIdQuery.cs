using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetAllOpenPositionsByIdQuery : IRequest<OpenPosition>
    {
        public Guid Id { get; set; }
        public class GetAllOpenPositionsByIdQueryHandler : IRequestHandler<GetAllOpenPositionsByIdQuery, OpenPosition>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOpenPositionsByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<OpenPosition> Handle(GetAllOpenPositionsByIdQuery query, CancellationToken cancellationToken)
            {
                var openPosition = _context.OpenPositions.Where(a => a.Id == query.Id).FirstOrDefault();

                if (openPosition == null) return null;
                return openPosition;
            }
        }
    }
}
