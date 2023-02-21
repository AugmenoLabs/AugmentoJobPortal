using Agumento.Core.Application.DTO;
using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.ScheduleInterviewFeatures.Queries
{
    public class GetAllScheduleInterviewsQuery : IRequest<IEnumerable<ScheduleInterviewDto>>
    {
        public class GetAllScheduleInterviewsQueryHandler : IRequestHandler<GetAllScheduleInterviewsQuery, IEnumerable<ScheduleInterviewDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllScheduleInterviewsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IEnumerable<ScheduleInterviewDto>> Handle(GetAllScheduleInterviewsQuery query, CancellationToken cancellationToken)
            {
                var ScheduleInterviewList = await _context.ScheduleInterviews.Select(s=> _mapper.Map<ScheduleInterviewDto>(s)).ToListAsync();

                if (ScheduleInterviewList == null)
                {
                    return null;
                }
                return ScheduleInterviewList.AsReadOnly();
            }
        }
    }
}
