using response=Agumento.Core.Application.ResponseObject;
using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.ScheduleInterviewFeatures.Commands
{
    public class CreateScheduleInterviewCommand : response.ScheduleInterview, IRequest<Guid>
    {
        // public Guid Id { get; set; }
        public class CreateScheduleInterviewCommandHandler : IRequestHandler<CreateScheduleInterviewCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateScheduleInterviewCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateScheduleInterviewCommand request, CancellationToken cancellationToken)
            {
                //ScheduleInterview ScheduleInterview = _mapper.Map<ScheduleInterview>(request);

                var ScheduleInterview = new ScheduleInterview();
                ScheduleInterview.Title = request.Title;
                ScheduleInterview.InterviewerName = request.InterviewerName;
                ScheduleInterview.InterviewerEmail = request.InterviewerEmail;
                ScheduleInterview.BCCEMail = request.BCCEMail;
                ScheduleInterview.CCEMail = request.CCEMail;
                ScheduleInterview.Round = request.Round;
                ScheduleInterview.ScheduledTimeFrom = request.ScheduledTimeFrom;
                ScheduleInterview.ScheduledTimeTo = request.ScheduledTimeTo;
                ScheduleInterview.ModeOfInterview = request.ModeOfInterview;
                ScheduleInterview.ContactNumber = request.ContactNumber;
                ScheduleInterview.MeetingLink = request.MeetingLink;
                ScheduleInterview.Details = request.Details;
                ScheduleInterview.CandidateId = request.CandidateId;

                _context.ScheduleInterviews.Add(ScheduleInterview);
                await _context.SaveChanges();

                return ScheduleInterview.Id;
            }


        }

    }
}
