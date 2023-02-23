using response = Agumento.Core.Application.ResponseObject;
using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.ScheduleInterviewFeatures.Queries
{
    public class GetAllScheduleInterviewsQuery : IRequest<IEnumerable<response.ScheduleInterview>>
    {
        public class GetAllScheduleInterviewsQueryHandler : IRequestHandler<GetAllScheduleInterviewsQuery, IEnumerable<response.ScheduleInterview>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllScheduleInterviewsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IEnumerable<response.ScheduleInterview>> Handle(GetAllScheduleInterviewsQuery query, CancellationToken cancellationToken)
            {
                var scheduleInterviewList = await _context.ScheduleInterviews.ToListAsync();
                var scheduleInterviews = _mapper.Map<List<response.ScheduleInterview>>(scheduleInterviewList);

                if (scheduleInterviews == null)
                {
                    return null;
                }

                return scheduleInterviews.AsReadOnly();
            }
        }
    }
}
