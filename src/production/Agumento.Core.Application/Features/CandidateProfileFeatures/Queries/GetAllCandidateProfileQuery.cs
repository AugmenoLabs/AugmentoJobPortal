using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.CandidateProfileFeatures.Queries
{
    public class GetAllCandidateProfileQuery : IRequest<IEnumerable<CandidateProfile>>
    {
        public class GetAllAccountsQueryHandler : IRequestHandler<GetAllCandidateProfileQuery, IEnumerable<CandidateProfile>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllAccountsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CandidateProfile>> Handle(GetAllCandidateProfileQuery query, CancellationToken cancellationToken)
            {
                var candidateProfileList = await _context.CandidateProfiles.ToListAsync();
                //var candidateProfileList = await _context.CandidateProfiles.Select(a => new
                //{
                //    a.CandidateName,
                //    a.Email,
                //    a.ContactNumber,
                //    a.ResidentialAddress,
                //    a.PermanenetAddress,
                //    a.Gender,
                //    a.Qualification,
                //    a.PrimarySkills,
                //    a.SecondarySkills,
                //    a.NoticePeriod,
                //    a.YearOfExperience,
                //    a.CurrentCTC,
                //    a.ExpectedCTC,
                //    a.HasOfferLetter,
                //    VendorName = _context.Vendors.Where(v => v.Id.Equals(a.Id)).Select(v => v.VendorName).FirstOrDefault(),
                //    OpenPositionName = _context.OpenPositions.Where(p => p.Id.Equals(a.VendorId)).Select(v => v.JobTitle).FirstOrDefault(),
                //    a.Resume
                //}).ToListAsync();

                if (candidateProfileList == null)
                {
                    return null;
                }
                return candidateProfileList.AsReadOnly();
            }

        }
    }
}

