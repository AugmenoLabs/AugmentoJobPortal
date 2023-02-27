using response = Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using AutoMapper;

namespace Agumento.Core.Application.AutoMapperProfile
{
    public class OpenPositionReportMapperProfile : Profile
    {
        public OpenPositionReportMapperProfile()
        {
            CreateMap<OpenPosition, response.OpenPositionReport>();
        }
    }
}
