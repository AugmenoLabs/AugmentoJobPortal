using response=Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using AutoMapper;

namespace Agumento.Core.Application.AutoMapperProfile
{
    public class ScheduleInterviewMapperProfile : Profile
    {
        public ScheduleInterviewMapperProfile()
        {
            CreateMap<ScheduleInterview, response.ScheduleInterview>();
        }
    }
}
