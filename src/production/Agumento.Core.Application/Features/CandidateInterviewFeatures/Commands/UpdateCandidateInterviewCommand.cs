using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.CandidateInterviewFeatures.Commands
{
    public class UpdateCandidateInterviewCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public virtual Guid CandidateId { get; set; }
        public string InterviewerName { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsSelected { get; set; }
        public string Feedback { get; set; }
        public string ModeOfInterview { get; set; }
        public string Level { get; set; }

        public class UpdateCandidateInterviewCommandHandler : IRequestHandler<UpdateCandidateInterviewCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public UpdateCandidateInterviewCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(UpdateCandidateInterviewCommand command, CancellationToken cancellationToken)
            {
                var candidateInterview = _context.CandidateInterviews.Where(a => a.Id == command.Id).FirstOrDefault();

                if (candidateInterview == null)
                {
                    return default;
                }
                else
                {
                    candidateInterview.CandidateId = command.CandidateId;
                    candidateInterview.InterviewerName = command.InterviewerName;
                    candidateInterview.ScheduledTime = command.ScheduledTime;
                    candidateInterview.IsSelected = command.IsSelected;
                    candidateInterview.Feedback = command.Feedback;
                    candidateInterview.ModeOfInterview = command.ModeOfInterview;
                    candidateInterview.Level = command.Level;

                    _context.CandidateInterviews.Update(candidateInterview);
                    await _context.SaveChanges();

                    return candidateInterview.Id;
                }
            }
        }
    }
}
