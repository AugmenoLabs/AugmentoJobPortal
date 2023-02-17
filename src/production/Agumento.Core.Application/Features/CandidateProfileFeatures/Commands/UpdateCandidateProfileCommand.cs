using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.CandidateProfileFeatures.Commands
{
    public class UpdateCandidateProfileCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public long ContactNumber { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PermanenetAddress { get; set; }
        public string Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public int YearOfExperience { get; set; }
        public string PrimarySkills { get; set; }
        public string? SecondarySkills { get; set; }
        public string? Qualification { get; set; }
        public virtual Guid OpenPositionId { get; set; }
        // public virtual OpenPosition OpenPosition { get; set; }        
        public virtual Guid VendorId { get; set; }
        // public virtual Vendor Vendor { get; set; }
        public long CurrentCTC { get; set; }
        public long ExpectedCTC { get; set; }
        public string NoticePeriod { get; set; }
        public bool HasOfferLetter { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public byte[] Resume { get; set; }

        public class UpdateCandidateProfileCommandHandler : IRequestHandler<UpdateCandidateProfileCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public UpdateCandidateProfileCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(UpdateCandidateProfileCommand command, CancellationToken cancellationToken)
            {
                var candidateProfile = _context.CandidateProfiles.Where(a => a.Id == command.Id).FirstOrDefault();

                if (candidateProfile == null)
                {
                    return default;
                }
                else
                {
                    candidateProfile.CandidateName = command.CandidateName;
                    candidateProfile.Email = command.Email;
                    candidateProfile.ContactNumber = command.ContactNumber;
                    candidateProfile.ResidentialAddress = command.ResidentialAddress;
                    candidateProfile.PermanenetAddress = command.PermanenetAddress;
                    candidateProfile.Gender = command.Gender;
                    candidateProfile.MaritalStatus = command.MaritalStatus;
                    candidateProfile.YearOfExperience = command.YearOfExperience;
                    candidateProfile.PrimarySkills = command.PrimarySkills;
                    candidateProfile.SecondarySkills = command.SecondarySkills;
                    candidateProfile.Qualification = command.Qualification;
                    candidateProfile.OpenPositionId = command.OpenPositionId;
                    candidateProfile.VendorId = command.VendorId;
                    candidateProfile.CurrentCTC = command.CurrentCTC;
                    candidateProfile.ExpectedCTC = command.ExpectedCTC;
                    candidateProfile.NoticePeriod = command.NoticePeriod;
                    candidateProfile.HasOfferLetter = command.HasOfferLetter;
                    candidateProfile.FileName = command.FileName;
                    candidateProfile.FileExt = command.FileExt;
                    candidateProfile.Resume = command.Resume;

                    _context.CandidateProfiles.Update(candidateProfile);
                    await _context.SaveChanges();

                    return candidateProfile.Id;
                }
            }
        }

    }
}
