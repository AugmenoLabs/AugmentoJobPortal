using Agumento.Core.Application.DTO;
using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.ScheduleInterviewFeatures.Queries
{
    public class GetScheduleInterviewByIdQuery : IRequest<ScheduleInterviewDto>
    {
        public Guid Id { get; set; }
        public class GetAccountByIdQueryHandler : IRequestHandler<GetScheduleInterviewByIdQuery, ScheduleInterviewDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;


            public GetAccountByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ScheduleInterviewDto> Handle(GetScheduleInterviewByIdQuery query, CancellationToken cancellationToken)
            {
                var ScheduleInterview = _context.ScheduleInterviews.Where(a => a.Id == query.Id).Select(s => _mapper.Map<ScheduleInterviewDto>(s)).FirstOrDefault();

                if (ScheduleInterview == null) return null;
                return ScheduleInterview;
            }
        }
    }
}
