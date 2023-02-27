﻿using Agumento.Core.Application.Interfaces;
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
                var candidateProfileScheduls = await (from c in _context.CandidateProfiles
                                                      join v in _context.Vendors on c.VendorId equals v.Id
                                                      join i in _context.ScheduleInterviews on c.Id equals i.CandidateId
                                                      join f in _context.CandidateInterviews on c.Id equals f.CandidateId
                                                      select new response.CandidateProfileSchedule
                                                      {
                                                          CandidateName = c.CandidateName,
                                                          Email = c.Email,
                                                          ContactNumber = c.ContactNumber,
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
                                                          FileExt = c.FileExt
                                                          //CandidateFeedbacks = c.
                                                      }).ToListAsync();

                return candidateProfileScheduls;
            }

        }
    }
}
