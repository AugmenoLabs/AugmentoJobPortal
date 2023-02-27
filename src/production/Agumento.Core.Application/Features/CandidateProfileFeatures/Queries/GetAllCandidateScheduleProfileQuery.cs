using Agumento.Core.Application.Interfaces;
using response = Agumento.Core.Application.ResponseObject;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Agumento.Core.Domain;

namespace Agumento.Core.Application.Features.CandidateProfileFeatures.Queries
{
    public class GetAllCandidateScheduleProfileQuery : IRequest<IEnumerable<response.CandidateProfileSchedule>>
    {
        public class GetAllCandidateScheduleProfileQueryHandler : IRequestHandler<GetAllCandidateScheduleProfileQuery, IEnumerable<response.CandidateProfileSchedule>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCandidateScheduleProfileQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<response.CandidateProfileSchedule>> Handle(GetAllCandidateScheduleProfileQuery query, CancellationToken cancellationToken)
            {
                var linqQuery = from c in _context.CandidateProfiles
                               join v in _context.Vendors on c.VendorId equals v.Id
                               join i in _context.ScheduleInterviews on c.Id equals i.CandidateId
                               join o in _context.OpenPositions on c.OpenPositionId equals o.Id
                               select new response.CandidateProfileSchedule
                               {
                                   CandidateName = c.CandidateName,
                                   Email = c.Email,
                                   ContactNumber = c.ContactNumber,
                                   AccountName = _context.Accounts.Where(ac => ac.Id.Equals(o.AccountId)).Select(a => a.AccountName).FirstOrDefault(),
                                   ProjectName = _context.Projects.Where(p => p.Id.Equals(o.ProjectId)).Select(a => a.ProjectName).FirstOrDefault(),
                                   ResidentialAddress = c.ResidentialAddress,
                                   PermanenetAddress = c.PermanenetAddress,
                                   Gender = c.Gender,
                                   MaritalStatus = c.MaritalStatus,
                                   YearOfExperience = c.YearOfExperience,
                                   PrimarySkills = c.PrimarySkills,
                                   SecondarySkills = c.SecondarySkills,
                                   Qualification = c.Qualification,
                                   OpenPositionId = c.OpenPositionId,
                                   VendorId = c.VendorId,
                                   VendorName = v.VendorName,
                                   NoticePeriod = c.NoticePeriod,
                                   ScheduleDate = i.ScheduledTimeFrom,
                                   InterviewerName = i.InterviewerName,
                                   HasOfferLetter = c.HasOfferLetter,
                                   Resume = c.Resume,
                                   FileName = c.FileName,
                                   FileExt = c.FileExt,
                                   CandidateFeedbacks = _context.CandidateInterviews.Where(a => a.CandidateId.Equals(c.Id)).ToList(),

                               };
                var candidateProfileScheduls = await (linqQuery).ToListAsync();

                return candidateProfileScheduls;
            }

        }
    }
}

