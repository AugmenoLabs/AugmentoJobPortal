using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.VendorFeatures.Commands
{
    public class UpdateVendorCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string SPOCName { get; set; }
        public long SPOCContactNumber { get; set; }
        public string SPOCEmail { get; set; }

        public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public UpdateVendorCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(UpdateVendorCommand command, CancellationToken cancellationToken)
            {
                var project = _context.Vendors.Where(a => a.Id == command.Id).FirstOrDefault();

                if (project == null)
                {
                    return default;
                }
                else
                {
                    var vendor = new Vendor();
                    vendor.VendorId = command.VendorId;
                    vendor.VendorName = command.VendorName;
                    vendor.SPOCName = command.SPOCName;
                    vendor.SPOCContactNumber = command.SPOCContactNumber;
                    vendor.SPOCEmail = command.SPOCEmail;

                    _context.Vendors.Add(vendor);
                    await _context.SaveChanges();

                    return project.Id;
                }
            }
        }
    }
}
