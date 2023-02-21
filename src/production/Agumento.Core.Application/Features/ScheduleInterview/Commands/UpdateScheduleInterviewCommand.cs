using Agumento.Core.Application.DTO;
using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.ScheduleInterviewFeatures.Commands
{
    public class UpdateScheduleInterviewCommand : ScheduleInterviewDto, IRequest<Guid>
    {
        public Guid Id { get; set; }
        //public string? ScheduleInterviewName { get; set; }
        //public string? ScheduleInterviewDetails { get; set; }
        //public string? ScheduleInterviewManager { get; set; }
        //public virtual Guid AccountId { get; set; }
        ////public virtual Account Account { get; set; }

        public class UpdateScheduleInterviewCommandHandler : IRequestHandler<UpdateScheduleInterviewCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public UpdateScheduleInterviewCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(UpdateScheduleInterviewCommand command, CancellationToken cancellationToken)
            {
                var ScheduleInterview = _context.ScheduleInterviews.Where(a => a.Id == command.Id).Select(s => _mapper.Map<ScheduleInterview>(s)).FirstOrDefault();

                if (ScheduleInterview == null)
                {
                    return default;
                }
                else
                {
                    //ScheduleInterview.Id = command.Id;

                    //ScheduleInterview.ScheduleInterviewName = command.ScheduleInterviewName;

                    //ScheduleInterview.ScheduleInterviewDetails = command.ScheduleInterviewDetails;

                    //ScheduleInterview.ScheduleInterviewManager = command.ScheduleInterviewManager;

                    //ScheduleInterview.AccountId = command.AccountId;

                    // ScheduleInterview.Account = command.Account;

                    _context.ScheduleInterviews.Update(ScheduleInterview);
                    await _context.SaveChanges();

                    return ScheduleInterview.Id;
                }
            }
        }
    }
}
