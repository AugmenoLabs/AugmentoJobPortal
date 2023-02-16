using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.VendorFeatures.Queries
{
    public class GetAllVendorsQuery : IRequest<IEnumerable<Vendor>>
    {
        public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, IEnumerable<Vendor>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllVendorsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Vendor>> Handle(GetAllVendorsQuery query, CancellationToken cancellationToken)
            {
                var vendors = await _context.Vendors.ToListAsync();

                if (vendors == null)
                {
                    return null;
                }
                return vendors.AsReadOnly();
            }
        }
    }
}
