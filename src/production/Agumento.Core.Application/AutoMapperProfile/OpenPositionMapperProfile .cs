using response = Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using AutoMapper;

namespace Agumento.Core.Application.AutoMapperProfile
{
    public class OpenPositionMapperProfile : Profile
    {
        public OpenPositionMapperProfile()
        {
            CreateMap<OpenPosition, response.OpenPosition>();
        }
    }
}
