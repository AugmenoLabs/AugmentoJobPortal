using Agumento.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.VendorFeatures.Commands
{
    public class DeleteVendorByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteVendorByIdCommandHandler : IRequestHandler<DeleteVendorByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteVendorByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteVendorByIdCommand command, CancellationToken cancellationToken)
            {
                var vendor = await _context.Vendors.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (vendor == null) return default;
                // _context.Projects.Remove(project);
                vendor.IsDeleted = true;
                _context.Vendors.Update(vendor);

                await _context.SaveChanges();
                return vendor.Id;
            }
        }
    }
}
