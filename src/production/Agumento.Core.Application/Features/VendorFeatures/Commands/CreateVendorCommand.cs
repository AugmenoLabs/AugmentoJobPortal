using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Agumento.Core.Application.Features.VendorFeatures.Commands
{
    public class CreateVendorCommand : IRequest<Guid>
    {
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string SPOCName { get; set; }
        public long SPOCContactNumber { get; set; }
        public string SPOCEmail { get; set; }

        public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateVendorCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
            {
                //Project project = _mapper.Map<Project>(request);
                var vendor = new Vendor();
                vendor.VendorId = GetVendorId(request.VendorName);
                vendor.VendorName = request.VendorName;
                vendor.SPOCName = request.SPOCName;
                vendor.SPOCContactNumber = request.SPOCContactNumber;
                vendor.SPOCEmail = request.SPOCEmail;

                _context.Vendors.Add(vendor);
                await _context.SaveChanges();

                return vendor.Id;
            }
            private string GetVendorId(string VendorName)
            {
                var name = VendorName == null ? "VD" : (VendorName.Length > 2 ? VendorName.Substring(0, 2).ToUpperInvariant() : VendorName.ToUpperInvariant());
                return name + " - " + Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));

            }


        }

    }
}
