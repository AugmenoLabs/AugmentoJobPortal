using Agumento.Core.Application.DTO;
using Agumento.Core.Domain;
using AutoMapper;

namespace Agumento.Core.Application.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ScheduleInterview, ScheduleInterviewDto>();
        }
    }
}
