﻿using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using Aspose.Words;
using AutoMapper;
using MediatR;
using System.IO;
using Document = Aspose.Words.Document;

namespace Agumento.Core.Application.Features.CandidateProfileFeatures.Commands
{
    public class CreateCandidateProfileCommand : IRequest<Guid>
    {
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public long ContactNumber { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PermanenetAddress { get; set; }
        public string Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public int YearOfExperience { get; set; }
        public string? PrimarySkills { get; set; }
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
        

        public class CreateCandidateProfileCommandHandler : IRequestHandler<CreateCandidateProfileCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateCandidateProfileCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(CreateCandidateProfileCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    //CandidateProfile candidateProfile = _mapper.Map<CandidateProfile>(request);
                    var candidateProfile = new CandidateProfile();

                    candidateProfile.CandidateName = request.CandidateName;
                    candidateProfile.Email = request.Email;
                    candidateProfile.ContactNumber = request.ContactNumber;
                    candidateProfile.ResidentialAddress = request.ResidentialAddress;
                    candidateProfile.PermanenetAddress = request.PermanenetAddress;
                    candidateProfile.Gender = request.Gender;
                    candidateProfile.MaritalStatus = request.MaritalStatus;
                    candidateProfile.YearOfExperience = request.YearOfExperience;
                    candidateProfile.PrimarySkills = request.PrimarySkills;
                    candidateProfile.SecondarySkills = request.SecondarySkills;
                    candidateProfile.Qualification = request.Qualification;
                    candidateProfile.OpenPositionId = request.OpenPositionId;
                    candidateProfile.VendorId = request.VendorId;
                    candidateProfile.CurrentCTC = request.CurrentCTC;
                    candidateProfile.ExpectedCTC = request.ExpectedCTC;
                    candidateProfile.NoticePeriod = request.NoticePeriod;
                    candidateProfile.HasOfferLetter = request.HasOfferLetter;
                    candidateProfile.FileName = request.FileName;
                    candidateProfile.FileExt = request.FileExt;
                    candidateProfile.Resume = request.Resume;

                    if (request.FileExt == "docx")
                    {
                        candidateProfile.Resume = WordToPdf(request.Resume);
                        candidateProfile.FileExt = "pdf";
                        candidateProfile.FileName = "Resume.pdf";
                    }


                    _context.CandidateProfiles.Add(candidateProfile);
                    await _context.SaveChanges();

                    return candidateProfile.Id;
                }
                catch(Exception ex)
                {
                    return Guid.NewGuid();
                }
            }

            private static Byte[] WordToPdf(byte[] resume)
            {
                // This represents the input byte array
                byte[] docBytes = resume;
                // Load Word Document from this byte array
                Document loadedFromBytes = new(new MemoryStream(docBytes));
                // Save Word to PDF byte array
                MemoryStream pdfStream = new();
                loadedFromBytes.Save(pdfStream, SaveFormat.Pdf);
                byte[] pdfBytes = pdfStream.ToArray();
                return pdfBytes;

            }
        }
    }
}
