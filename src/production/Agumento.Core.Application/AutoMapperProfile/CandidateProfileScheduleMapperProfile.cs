using response = Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using AutoMapper;

namespace Agumento.Core.Application.AutoMapperProfile
{
    public class CandidateProfileScheduleMapperProfile : Profile
    {
        public CandidateProfileScheduleMapperProfile()
        {
            CreateMap<CandidateProfile, response.CandidateProfileSchedule>();
        }
    }
}
