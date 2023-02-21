using Agumento.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.ScheduleInterviewFeatures.Commands
{
    public class DeleteScheduleInterviewByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteScheduleInterviewIdCommandHandler : IRequestHandler<DeleteScheduleInterviewByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteScheduleInterviewIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteScheduleInterviewByIdCommand command, CancellationToken cancellationToken)
            {
                var ScheduleInterview = await _context.ScheduleInterviews.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (ScheduleInterview == null) return default;
                // _context.ScheduleInterviews.Remove(ScheduleInterview);
                ScheduleInterview.IsDeleted = true;
                _context.ScheduleInterviews.Update(ScheduleInterview);

                await _context.SaveChanges();
                return ScheduleInterview.Id;
            }
        }
    }
}
