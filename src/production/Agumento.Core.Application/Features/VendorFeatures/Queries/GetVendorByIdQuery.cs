using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;

namespace Agumento.Core.Application.Features.VendorFeatures.Queries
{
    public class GetVendorByIdQuery : IRequest<Vendor>
    {
        public Guid Id { get; set; }
        public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, Vendor>
        {
            private readonly IApplicationDbContext _context;
            public GetVendorByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Vendor> Handle(GetVendorByIdQuery query, CancellationToken cancellationToken)
            {
                var vendor = _context.Vendors.Where(a => a.Id == query.Id).FirstOrDefault();

                if (vendor == null) return null;
                return vendor;
            }
        }
    }
}
