using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.CandidateInterviewFeatures.Commands
{
    public class CreateCandidateInterviewCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public virtual Guid CandidateId { get; set; }
        public string InterviewerName { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsSelected { get; set; }
        public string Feedback { get; set; }
        public string ModeOfInterview { get; set; }
        public string Level { get; set; }

        public class CreateCandidateInterviewCommandHandler : IRequestHandler<CreateCandidateInterviewCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateCandidateInterviewCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateCandidateInterviewCommand request, CancellationToken cancellationToken)
            {
                //Project project = _mapper.Map<Project>(request);
                var candidateInterview = new CandidateInterview();

                candidateInterview.CandidateId = request.CandidateId;
                candidateInterview.InterviewerName = request.InterviewerName;
                candidateInterview.ScheduledTime = request.ScheduledTime;
                candidateInterview.IsSelected = request.IsSelected;
                candidateInterview.Feedback = request.Feedback;
                candidateInterview.ModeOfInterview = request.ModeOfInterview;
                candidateInterview.Level = request.Level;

                _context.CandidateInterviews.Add(candidateInterview);
                await _context.SaveChanges();

                return candidateInterview.Id;
            }


        }

    }
}
